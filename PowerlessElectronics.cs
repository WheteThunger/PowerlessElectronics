// TODO: Permissions
// TODO: Configuration (enabled, energy amount, required permissions, global energy amount)
namespace Oxide.Plugins
{
    [Info("Powerless Electronics", "WhiteThunder", "0.1.0")]
    [Description("Allows various electrical entities to generate their own power when not plugged in.")]
    internal class PowerlessElectronics : CovalencePlugin
    {
        #region Fields

        // max is 10 million
        private const int FreePower = 1001;

        #endregion

        #region Hooks

        private void Init()
        {
            Unsubscribe(nameof(OnEntitySpawned));
        }

        private void OnServerInitialized()
        {
            foreach (var entity in BaseNetworkable.serverEntities)
            {
                var ioEntity = entity as IOEntity;
                if (ioEntity != null)
                    OnEntitySpawned(ioEntity);
            }

            Subscribe(nameof(OnEntitySpawned));
        }

        private void OnEntitySpawned(IOEntity ioEntity)
        {
            ProcessIOEntity(ioEntity);
        }

        private void OnIORefCleared(IOEntity.IORef ioRef, IOEntity ioEntity)
        {
            if (ioEntity == null)
                return;

            NextTick(() =>
            {
                if (ioEntity == null)
                    return;

                ProcessIOEntity(ioEntity);
            });
        }

        #endregion

        #region Helper Methods

        private void ProcessIOEntity(IOEntity ioEntity)
        {
            if (HasOnePowerInput(ioEntity))
            {
                if (!HasInput(ioEntity, 0))
                    TryProvidePower(ioEntity, 0);

                return;
            }

            if (HasTwoPowerInputs(ioEntity))
            {
                if (!HasInput(ioEntity, 0))
                    ioEntity.UpdateFromInput(FreePower, 0);

                if (!HasInput(ioEntity, 1))
                    ioEntity.UpdateFromInput(FreePower, 1);

                return;
            }
        }

        private bool HasInput(IOEntity ioEntity, int inputSlot) =>
            inputSlot < ioEntity.inputs.Length &&
            ioEntity.inputs[inputSlot].connectedTo.Get() != null;

        private bool HasOnePowerInput(IOEntity ioEntity)
        {
            return
                ioEntity is AdvancedChristmasLights ||
                ioEntity is ElectricalBranch ||
                ioEntity is ElectricalBlocker || // TODO: Differentiate from RANDSwitch
                ioEntity is ElectricalDFlipFlop ||
                ioEntity is ElectricalHeater ||
                ioEntity is ElectricSwitch ||
                ioEntity is CeilingLight ||
                ioEntity is ElevatorIOEntity ||
                ioEntity is FlasherLight ||
                ioEntity is HBHFSensor ||
                ioEntity is LaserDetector ||
                ioEntity is ModularCarGarage ||
                ioEntity is PowerCounter ||
                ioEntity is PressButton ||
                ioEntity is PressurePad ||
                ioEntity is RFReceiver ||
                ioEntity is SamSite ||
                ioEntity is SearchLight ||
                ioEntity is SirenLight ||
                ioEntity is SmartSwitch ||
                ioEntity is Splitter ||
                ioEntity is StorageMonitor ||
                ioEntity is Telephone ||
                ioEntity is TimerSwitch;
        }

        private bool HasTwoPowerInputs(IOEntity ioEntity)
        {
            return
                ioEntity is ElectricalCombiner ||
                ioEntity is ANDSwitch;
        }

        private void TryProvidePower(IOEntity ioEntity, int inputSlot = 0)
        {
            if (ioEntity.inputs.Length > inputSlot)
                ioEntity.UpdateFromInput(FreePower, inputSlot);
        }

        #endregion
    }
}
