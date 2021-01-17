using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oxide.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins
{
    [Info("Powerless Electronics", "WhiteThunder", "0.1.0")]
    [Description("Allows electrical entities to generate their own power when not plugged in.")]
    internal class PowerlessElectronics : CovalencePlugin
    {
        #region Fields

        private const string PermissionAll = "powerlesselectronics.all";
        private const string PermissionEntityFormat = "powerlesselectronics.{0}";

        private Configuration _pluginConfig;

        #endregion

        #region Hooks

        private void Init()
        {
            _pluginConfig.GeneratePermissionNames();

            permission.RegisterPermission(PermissionAll, this);
            foreach (var entry in _pluginConfig.Entities)
                permission.RegisterPermission(entry.Value.PermissionName, this);

            Unsubscribe(nameof(OnEntitySpawned));
        }

        private void OnServerInitialized()
        {
            foreach (var entity in BaseNetworkable.serverEntities)
            {
                var ioEntity = entity as IOEntity;
                if (ioEntity != null)
                    ProcessIOEntity(ioEntity, delay: false);
            }

            Subscribe(nameof(OnEntitySpawned));
        }

        private void OnEntitySpawned(IOEntity ioEntity)
        {
            ProcessIOEntity(ioEntity, delay: true);
        }

        private void OnIORefCleared(IOEntity.IORef ioRef, IOEntity ioEntity)
        {
            ProcessIOEntity(ioEntity, delay: true);
        }

        #endregion

        #region Helper Methods

        private static bool InputUpdateWasBlocked(IOEntity ioEntity, int inputSlot, int amount)
        {
            object hookResult = Interface.CallHook("OnPowerlessInputUpdate", inputSlot, ioEntity, amount);
            return hookResult is bool && (bool)hookResult == false;
        }

        private static void MaybeProvidePower(IOEntity ioEntity, EntityConfig entityConfig)
        {
            // This is placed here instead of in the calling method in case it needs to be delayed
            // Since many IO entities may be parented after spawn to work around the rendering bug
            if (ShouldIngoreEntity(ioEntity))
                return;

            for (var i = 0; i < entityConfig.InputSlots.Length; i++)
            {
                var inputSlot = entityConfig.InputSlots[i];
                var powerAmount = entityConfig.GetPowerForSlot(inputSlot);

                // Don't update power if specified to be 0 to avoid conflicts with other plugins
                if (powerAmount > 0 && !HasConnectedInput(ioEntity, inputSlot))
                    TryProvidePower(ioEntity, inputSlot, powerAmount);
            }
        }

        private static bool ShouldIngoreEntity(IOEntity ioEntity)
        {
            // Parented entities are assumed to be controlled by other plugins that can manage power themselves
            // Exception being elevator io entities and storage monitors which are parented in vanilla
            if (ioEntity.HasParent() & !(ioEntity is ElevatorIOEntity) && !(ioEntity is StorageMonitor))
                return true;

            // Turrets and sam sites with switches on them are assumed to be controlled by other plugins
            if ((ioEntity is AutoTurret || ioEntity is SamSite) && GetChildEntity<ElectricSwitch>(ioEntity) != null)
                return true;

            return false;
        }

        private static T GetChildEntity<T>(BaseEntity entity) where T : BaseEntity
        {
            for (var i = 0; i < entity.children.Count; i++)
            {
                var child = entity.children[i] as T;
                if (child != null)
                    return child;
            }
            return null;
        }

        private static bool HasConnectedInput(IOEntity ioEntity, int inputSlot) =>
            inputSlot < ioEntity.inputs.Length &&
            ioEntity.inputs[inputSlot].connectedTo.Get() != null;

        private static void TryProvidePower(IOEntity ioEntity, int inputSlot, int powerAmount)
        {
            if (ioEntity.inputs.Length > inputSlot && !InputUpdateWasBlocked(ioEntity, inputSlot, powerAmount))
                ioEntity.UpdateFromInput(powerAmount, inputSlot);
        }

        private void ProcessIOEntity(IOEntity ioEntity, bool delay)
        {
            if (ioEntity == null)
                return;

            var entityConfig = GetEntityConfig(ioEntity);

            // Entity not supported
            if (entityConfig == null)
                return;

            if (!entityConfig.Enabled)
                return;

            if (!EntityOwnerHasPermission(ioEntity, entityConfig))
                return;

            if (delay)
            {
                NextTick(() =>
                {
                    if (ioEntity == null)
                        return;

                    MaybeProvidePower(ioEntity, entityConfig);
                });
            }
            else
            {
                MaybeProvidePower(ioEntity, entityConfig);
            }
        }

        private bool EntityOwnerHasPermission(BaseEntity entity, EntityConfig entityConfig)
        {
            if (!entityConfig.RequirePermission)
                return true;

            if (entity.OwnerID == 0)
                return false;

            var ownerIdString = entity.OwnerID.ToString();

            return permission.UserHasPermission(ownerIdString, PermissionAll) ||
                permission.UserHasPermission(ownerIdString, entityConfig.PermissionName);
        }

        #endregion

        #region Configuration

        private EntityConfig GetEntityConfig(IOEntity ioEntity)
        {
            EntityConfig entityConfig;
            return _pluginConfig.Entities.TryGetValue(ioEntity.ShortPrefabName, out entityConfig) ? entityConfig : null;
        }

        private class Configuration : SerializableConfiguration
        {
            public void GeneratePermissionNames()
            {
                foreach (var entry in Entities)
                {
                    // Make the permission name less redundant
                    entry.Value.PermissionName = string.Format(PermissionEntityFormat, entry.Key)
                        .Replace("electric.", string.Empty)
                        .Replace("electrical.", string.Empty)
                        .Replace(".deployed", string.Empty)
                        .Replace("_deployed", string.Empty)
                        .Replace(".entity", string.Empty);
                }
            }

            public Dictionary<string, EntityConfig> Entities = new Dictionary<string, EntityConfig>()
            {
                ["andswitch.entity"] = new EntityConfig() { InputSlots = new int[] { 0, 1 }, PowerAmounts = new int[] { 0, 0 } },
                ["audioalarm"] = new EntityConfig(),
                ["autoturret_deployed"] = new EntityConfig(),
                ["button"] = new EntityConfig(),
                ["cctv_deployed"] = new EntityConfig(),
                ["ceilinglight.deployed"] = new EntityConfig(),
                ["counter"] = new EntityConfig(),
                ["doorcontroller.deployed"] = new EntityConfig(),
                ["electric.flasherlight.deployed"] = new EntityConfig(),
                ["electric.sirenlight.deployed"] = new EntityConfig(),
                ["electrical.blocker.deployed"] = new EntityConfig(),
                ["electrical.branch.deployed"] = new EntityConfig(),
                ["electrical.combiner.deployed"] = new EntityConfig() { InputSlots = new int[] { 0, 1 }, PowerAmounts = new int[] { 0, 0 } },
                ["electrical.heater"] = new EntityConfig(),
                ["electrical.memorycell.deployed"] = new EntityConfig(),
                ["electrical.modularcarlift.deployed"] = new EntityConfig(),
                ["electrical.random.switch.deployed"] = new EntityConfig(),
                ["elevatorioentity"] = new EntityConfig(),
                ["fluidswitch"] = new EntityConfig() { InputSlots = new int[] { 2 } },
                ["hbhfsensor.deployed"] = new EntityConfig(),
                ["igniter.deployed"] = new EntityConfig(),
                ["laserdetector"] = new EntityConfig(),
                ["large.rechargable.battery.deployed"] = new EntityConfig(),
                ["medium.rechargable.battery.deployed"] = new EntityConfig(),
                ["orswitch.entity"] = new EntityConfig() { InputSlots = new int[] { 0, 1 }, PowerAmounts = new int[] { 0, 0 } },
                ["poweredwaterpurifier.deployed"] = new EntityConfig() { InputSlots = new int[] { 1 } },
                ["pressurepad.deployed"] = new EntityConfig(),
                ["reactivetarget_deployed"] = new EntityConfig(),
                ["rfbroadcaster"] = new EntityConfig(),
                ["rfreceiver"] = new EntityConfig(),
                ["sam_site_turret_deployed"] = new EntityConfig(),
                ["searchlight.deployed"] = new EntityConfig(),
                ["sign.neon.125x125"] = new EntityConfig(),
                ["sign.neon.125x215.animated"] = new EntityConfig(),
                ["sign.neon.125x215"] = new EntityConfig(),
                ["sign.neon.xl.animated"] = new EntityConfig(),
                ["sign.neon.xl"] = new EntityConfig(),
                ["simplelight"] = new EntityConfig(),
                ["smallrechargablebattery.deployed"] = new EntityConfig(),
                ["smartalarm"] = new EntityConfig(),
                ["smartswitch"] = new EntityConfig(),
                ["splitter"] = new EntityConfig(),
                ["storagemonitor.deployed"] = new EntityConfig(),
                ["switch"] = new EntityConfig(),
                ["telephone.deployed"] = new EntityConfig(),
                ["teslacoil.deployed"] = new EntityConfig(),
                ["timer"] = new EntityConfig(),
                ["water.pump.deployed"] = new EntityConfig(),
                ["xmas.advanced.lights.deployed"] = new EntityConfig(),
                ["xorswitch.entity"] = new EntityConfig() { InputSlots = new int[] { 0, 1 }, PowerAmounts = new int[] { 0, 0 } },
            };
        }

        internal class EntityConfig
        {
            private static readonly int[] StandardInputSlot = new int[] { 0 };

            [JsonProperty("RequirePermission")]
            public bool RequirePermission = false;

            // Hidden from config when it's using the default value
            [JsonProperty("InputSlots")]
            public int[] InputSlots = StandardInputSlot;

            public bool ShouldSerializeInputSlots() =>
                !InputSlots.SequenceEqual(StandardInputSlot);

            // Hidden from config when the plural form is used
            [JsonProperty("PowerAmount")]
            public int PowerAmount = 0;

            public bool ShouldSerializePowerAmount() =>
                PowerAmounts == null;

            // Hidden from config when null
            [JsonProperty("PowerAmounts", DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int[] PowerAmounts;

            [JsonIgnore]
            public string PermissionName;

            [JsonIgnore]
            public bool Enabled
            {
                get
                {
                    for (var i = 0; i < InputSlots.Length; i++)
                        if (GetPowerForSlot(InputSlots[i]) > 0)
                            return true;

                    return false;
                }
            }

            public int GetPowerForSlot(int slotNumber)
            {
                var index = Array.IndexOf(InputSlots, slotNumber);

                // We can't power an input slot that we don't know about
                if (index == -1)
                    return 0;

                // Allow plural array form to take precedence if present
                if (PowerAmounts == null)
                    return PowerAmount;

                // InputSlots and PowerAmounts are expected to be parallel arrays
                return index < PowerAmounts.Length ? PowerAmounts[index] : 0;
            }
        }

        private Configuration GetDefaultConfig() => new Configuration();

        #endregion

        #region Configuration Boilerplate

        private class SerializableConfiguration
        {
            public string ToJson() => JsonConvert.SerializeObject(this);

            public Dictionary<string, object> ToDictionary() => JsonHelper.Deserialize(ToJson()) as Dictionary<string, object>;
        }

        private static class JsonHelper
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

        protected override void LoadDefaultConfig() => _pluginConfig = GetDefaultConfig();

        protected override void LoadConfig()
        {
            base.LoadConfig();
            try
            {
                _pluginConfig = Config.ReadObject<Configuration>();
                if (_pluginConfig == null)
                {
                    throw new JsonException();
                }

                if (MaybeUpdateConfig(_pluginConfig))
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
            Config.WriteObject(_pluginConfig, true);
        }

        #endregion
    }
}
