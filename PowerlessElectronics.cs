using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

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

        private Configuration pluginConfig;

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
            if (ioEntity is FluidSwitch)
            {
                if (!HasInput(ioEntity, 2))
                    ioEntity.UpdateFromInput(FreePower, 2);

                return;
            }

            if (ioEntity is WaterPurifier)
            {
                if (!HasInput(ioEntity, 1))
                    ioEntity.UpdateFromInput(FreePower, 1);

                return;
            }

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
                ioEntity is AudioAlarm ||  // TODO: Disable by default
                ioEntity is CeilingLight ||
                ioEntity is CCTV_RC ||
                ioEntity is ElectricalBranch ||
                ioEntity is ElectricalBlocker || // TODO: Differentiate from RANDSwitch
                ioEntity is ElectricalDFlipFlop ||
                ioEntity is ElectricalHeater ||
                ioEntity is ElectricSwitch || // TODO: Differentiate from FluidSwitch
                ioEntity is ElevatorIOEntity ||
                ioEntity is FlasherLight ||
                ioEntity is FluidSwitch ||
                ioEntity is Igniter || // TODO: Disable by default
                ioEntity is HBHFSensor ||
                ioEntity is LaserDetector ||
                ioEntity is ModularCarGarage ||
                ioEntity is NeonSign ||
                ioEntity is PowerCounter ||
                ioEntity is PressButton ||
                ioEntity is PressurePad ||
                ioEntity is ReactiveTarget ||
                ioEntity is RFReceiver ||
                ioEntity is SamSite ||
                ioEntity is SearchLight ||
                ioEntity is SimpleLight ||
                ioEntity is SirenLight ||
                ioEntity is SmartSwitch ||
                ioEntity is Splitter ||
                ioEntity is StorageMonitor ||
                ioEntity is Telephone ||
                ioEntity is TimerSwitch ||
                ioEntity is WaterPump;
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

        #region Configuration

        internal class Configuration : SerializableConfiguration
        {
            
        }

        private Configuration GetDefaultConfig() => new Configuration();

        #endregion

        #region Configuration Boilerplate

        internal class SerializableConfiguration
        {
            public string ToJson() => JsonConvert.SerializeObject(this);

            public Dictionary<string, object> ToDictionary() => JsonHelper.Deserialize(ToJson()) as Dictionary<string, object>;
        }

        internal static class JsonHelper
        {
            public static object Deserialize(string json) => ToObject(JToken.Parse(json));

            private static object ToObject(JToken token)
            {
                switch (token.Type)
                {
                    case JTokenType.Object:
                        return token.Children<JProperty>()
                                    .ToDictionary(prop => prop.Name,
                                                  prop => ToObject(prop.Value));

                    case JTokenType.Array:
                        return token.Select(ToObject).ToList();

                    default:
                        return ((JValue)token).Value;
                }
            }
        }

        private bool MaybeUpdateConfig(SerializableConfiguration config)
        {
            var currentWithDefaults = config.ToDictionary();
            var currentRaw = Config.ToDictionary(x => x.Key, x => x.Value);
            return MaybeUpdateConfigDict(currentWithDefaults, currentRaw);
        }

        private bool MaybeUpdateConfigDict(Dictionary<string, object> currentWithDefaults, Dictionary<string, object> currentRaw)
        {
            bool changed = false;

            foreach (var key in currentWithDefaults.Keys)
            {
                object currentRawValue;
                if (currentRaw.TryGetValue(key, out currentRawValue))
                {
                    var defaultDictValue = currentWithDefaults[key] as Dictionary<string, object>;
                    var currentDictValue = currentRawValue as Dictionary<string, object>;

                    if (defaultDictValue != null)
                    {
                        if (currentDictValue == null)
                        {
                            currentRaw[key] = currentWithDefaults[key];
                            changed = true;
                        }
                        else if (MaybeUpdateConfigDict(defaultDictValue, currentDictValue))
                            changed = true;
                    }
                }
                else
                {
                    currentRaw[key] = currentWithDefaults[key];
                    changed = true;
                }
            }

            return changed;
        }

        protected override void LoadDefaultConfig() => pluginConfig = GetDefaultConfig();

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                pluginConfig = Config.ReadObject<Configuration>();
                if (pluginConfig == null)
                {
                    throw new JsonException();
                }

                if (MaybeUpdateConfig(pluginConfig))
                {
                    LogWarning("Configuration appears to be outdated; updating and saving");
                    SaveConfig();
                }
            }
            catch
            {
                LogWarning($"Configuration file {Name}.json is invalid; using defaults");
                LoadDefaultConfig();
            }
        }

        protected override void SaveConfig()
        {
            Log($"Configuration changes saved to {Name}.json");
            Config.WriteObject(pluginConfig, true);
        }

        #endregion
    }
}
