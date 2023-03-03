## Features

- Allows any electrical entity to generate a configurable amount of power
  - Allows making entities effectively powerless by generating exactly the power they require (e.g., 3 for Electric Heaters)
  - Allows making entities function as test generators by generating more power than they need (e.g., 1000 for Splitters)
- Optionally only applies to entities deployed by players with permissions, configurable per entity type
- Designed to work with circuits, so inputs with a wire in them are ignored

Note: This plugin does **not** allow altering power consumption itself, nor does it allow altering power generation of vanilla generators such as solar panels.

## Installation

1. Add the plugin to the `oxide/plugins` directory of your Rust server installation
2. Update the plugin configuration to determine how much free power each entity type should get and whether permissions should be required
3. Grant permissions if applicable from the previous step (see Permissions section)
4. Reload the plugin

If you configured the plugin correctly, then:
- Existing entities that were not plugged in will automatically be provided with the power amount you configured
- Existing entities that were plugged in will be unaffected initially, but disconnecting the input wires will immediately cause those entities to generate the power amount you configured
- Entities deployed later will automatically be provided the power amount you configured

### Troubleshooting

- After granting permissions or roles, you will need to reload the plugin to automatically power existing entities
- Make sure you grant permissions for each entity that you configured with `"RequirePermission": true` (off by default)
- Make sure that the amount of power you configured for each entity is at least the power requirement, or there will be no effect
  - The configuration section below lists the power requirement for most entities to help you configure the plugin for your use case

## Permissions

Note: Permissions are only necessary if the corresponding entity's configuration has specified `"RequirePermission": true`. The default is `false` for all entities.

- `powerlesselectronics.all` -- All electrical entities deployed by players with this permission will have free power determined by the plugin configuration. You must also configure the power amount for each entity for this to have any effect.

As an alternative to the `all` permission, you can grant permissions by entity type. These are automatically generated from the plugin configuration.

- `powerlesselectronics.andswitch`
- `powerlesselectronics.audioalarm`
- `powerlesselectronics.autoturret`
- `powerlesselectronics.blocker`
- `powerlesselectronics.boombox`
- `powerlesselectronics.branch`
- `powerlesselectronics.button`
- `powerlesselectronics.cctv`
- `powerlesselectronics.ceilinglight`
- `powerlesselectronics.combiner`
- `powerlesselectronics.counter`
- `powerlesselectronics.discoball`
- `powerlesselectronics.discofloor.largetiles`
- `powerlesselectronics.discofloor`
- `powerlesselectronics.doorcontroller`
- `powerlesselectronics.electricfurnace.io`
- `powerlesselectronics.elevatorioentity`
- `powerlesselectronics.flasherlight`
- `powerlesselectronics.fluidswitch`
- `powerlesselectronics.hbhfsensor`
- `powerlesselectronics.heater`
- `powerlesselectronics.igniter`
- `powerlesselectronics.industrial.wall.lamp.green`
- `powerlesselectronics.industrial.wall.lamp.red`
- `powerlesselectronics.industrial.wall.lamp`
- `powerlesselectronics.industrialconveyor`
- `powerlesselectronics.industrialcrafter`
- `powerlesselectronics.large.rechargable.battery`
- `powerlesselectronics.laserdetector`
- `powerlesselectronics.laserlight`
- `powerlesselectronics.medium.rechargable.battery`
- `powerlesselectronics.memorycell`
- `powerlesselectronics.microphonestandio`
- `powerlesselectronics.modularcarlift`
- `powerlesselectronics.orswitch`
- `powerlesselectronics.poweredwaterpurifier`
- `powerlesselectronics.pressurepad`
- `powerlesselectronics.ptz_cctv`
- `powerlesselectronics.random.switch`
- `powerlesselectronics.reactivetarget`
- `powerlesselectronics.rfbroadcaster`
- `powerlesselectronics.rfreceiver`
- `powerlesselectronics.sam_site_turret`
- `powerlesselectronics.searchlight`
- `powerlesselectronics.sign.neon.125x125`
- `powerlesselectronics.sign.neon.125x215.animated`
- `powerlesselectronics.sign.neon.125x215`
- `powerlesselectronics.sign.neon.xl.animated`
- `powerlesselectronics.sign.neon.xl`
- `powerlesselectronics.simplelight`
- `powerlesselectronics.sirenlight`
- `powerlesselectronics.smallrechargablebattery`
- `powerlesselectronics.smartalarm`
- `powerlesselectronics.smartswitch`
- `powerlesselectronics.splitter`
- `powerlesselectronics.storagemonitor`
- `powerlesselectronics.switch`
- `powerlesselectronics.telephone`
- `powerlesselectronics.teslacoil`
- `powerlesselectronics.timer`
- `powerlesselectronics.water.pump`
- `powerlesselectronics.xmas.advanced.lights`
- `powerlesselectronics.xorswitch`

## Configuration

Default configuration (no entities provide free power):

```json
{
  "Entities": {
    "andswitch.entity": {
      "RequirePermission": false,
      "InputSlots": [
        0,
        1
      ],
      "PowerAmounts": [
        0,
        0
      ]
    },
    "audioalarm": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "autoturret_deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "boombox.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "button": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "cctv_deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "ceilinglight.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "counter": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "discoball.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "discofloor.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "discofloor.largetiles.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "doorcontroller.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electric.flasherlight.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electric.sirenlight.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.blocker.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.branch.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.combiner.deployed": {
      "RequirePermission": false,
      "InputSlots": [
        0,
        1
      ],
      "PowerAmounts": [
        0,
        0
      ]
    },
    "electrical.heater": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.memorycell.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.modularcarlift.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electrical.random.switch.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "electricfurnace.io": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "elevatorioentity": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "fluidswitch": {
      "RequirePermission": false,
      "InputSlots": [
        2
      ],
      "PowerAmount": 0
    },
    "hbhfsensor.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "igniter.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "industrial.wall.lamp.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "industrial.wall.lamp.green.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "industrial.wall.lamp.red.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "industrialconveyor.deployed": {
      "RequirePermission": false,
      "InputSlots": [
        1
      ],
      "PowerAmount": 0
    },
    "industrialcrafter.deployed": {
      "RequirePermission": false,
      "InputSlots": [
        1
      ],
      "PowerAmount": 0
    },
    "large.rechargable.battery.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "laserdetector": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "laserlight.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "medium.rechargable.battery.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "microphonestandio.entity": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "orswitch.entity": {
      "RequirePermission": false,
      "InputSlots": [
        0,
        1
      ],
      "PowerAmounts": [
        0,
        0
      ]
    },
    "poweredwaterpurifier.deployed": {
      "RequirePermission": false,
      "InputSlots": [
        1
      ],
      "PowerAmount": 0
    },
    "pressurepad.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "ptz_cctv_deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "reactivetarget_deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "rfbroadcaster": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "rfreceiver": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sam_site_turret_deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "searchlight.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.125x125": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.125x215": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.125x215.animated": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.xl": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.xl.animated": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "simplelight": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "smallrechargablebattery.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "smartalarm": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "smartswitch": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "splitter": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "storagemonitor.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "switch": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "telephone.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "teslacoil.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "timer": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "water.pump.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "xmas.advanced.lights.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "xorswitch.entity": {
      "RequirePermission": false,
      "InputSlots": [
        0,
        1
      ],
      "PowerAmounts": [
        0,
        0
      ]
    }
  }
}
```

Each entity type has the following configuration options, mapped in the config to the entity's prefab short name.

- `RequirePermission` (`true` or `false`) -- While `true`, only entities of this type that were deployed by players with the corresponding permission will receive the power configured here. While `false`, all entities of this type will have the power configured here.
- `PowerAmount` -- Amount of power to provide to each input where a wire is missing.
- `PowerAmounts` -- List of power amounts, applicable when the entity has multiple power inputs. You can also use the `PowerAmount` (singular) option to apply the same amount to all inputs.
- `InputSlots` (Advanced) -- You should only need to configure this option if you want to provide free power for an entity that is not yet in the plugin's default configuration, such as when new items are introduced to the game. This option controls which internal slot numbers to assign power to. Most entities only have one power input which is usually at slot `0`, but some have multiple or use different numbers due to also having water inputs.

Note: This plugin ignores any input slot which is configured with `0` power, so it will not interfere with other plugins that provide powerless functionality. The only gotcha is that if you provided free power to an entity via this plugin and then changed the configuration to provide `0` power, the entity will have free power until a wire is connected to that input, or until the next server restart.

### Entity power requirements

To help you configure the plugin for your use case, the minimum amount of useful power for each entity is listed below. These may be a little higher than the power requirement since some entities are effectively useless without providing extra power for the outputs. I have added a + for entities where adding more power provides a useful function besides simple passthrough.

- `andswitch.entity`: 2+, 2+
- `audioalarm`: 1
- `autoturret_deployed`: 10+
- `button`: 2+
- `boombox.deployed`: 1+
- `cctv_deployed`: 3
- `ceilinglight.deployed`: 2
- `counter`: 1+
- `discoball.deployed`: 1+
- `discofloor.deployed`: 1+
- `discofloor.largetiles.deployed`: 1+
- `doorcontroller.deployed`: 1+
- `electricfurnace.io`: 3
- `electric.flasherlight.deployed`: 1
- `electric.sirenlight.deployed`: 1
- `electrical.blocker.deployed`: 2+
- `electrical.branch.deployed`: 4+
- `electrical.combiner.deployed`: 1+, 1+
- `electrical.heater`: 3
- `electrical.memorycell.deployed`: 1+
- `electrical.modularcarlift.deployed`: 5
- `electrical.random.switch.deployed`: 2+
- `elevatorioentity`: 5
- `fluidswitch`: 1
- `hbhfsensor.deployed`: 2+
- `igniter.deployed`: 2
- `industrial.wall.lamp.deployed`: 1
- `industrial.wall.lamp.green.deployed`: 1
- `industrial.wall.lamp.red.deployed`: 1
- `industrialconveyor.deployed`: 1
- `industrialcrafter.deployed`: 1
- `laserdetector`: 2+
- `laserlight.deployed`: 1+
- `microphonestandio`: 1+
- `orswitch.entity`: 2+, 2+
- `poweredwaterpurifier.deployed`: 5
- `pressurepad.deployed`: 2+
- `ptz_cctv_deployed`: 3
- `reactivetarget_deployed`: 2+
- `rfbroadcaster`: 1
- `rfreceiver`: 2+
- `sam_site_turret_deployed`: 25
- `searchlight.deployed`: 10
- `sign.neon.125x125`: 4
- `sign.neon.125x215`: 6
- `sign.neon.125x215.animated`: 10
- `sign.neon.xl`: 8
- `sign.neon.xl.animated`: 15
- `simplelight`: 1
- `smartalarm`: 1
- `smartswitch`: 2+
- `splitter`: 4+
- `storagemonitor.deployed`: 1+
- `switch`: 2+
- `telephone.deployed`: 1+
- `teslacoil.deployed`: 1-35
- `timer`: 2+
- `water.pump.deployed`: 5
- `xmas.advanced.lights.deployed`: 5
- `xorswitch.entity`: 1+

## FAQ

**Q: Why would I provide free power to a branch or splitter?**

A: To allow them to function as essentially a test generator with multiple outputs. Very useful.

**Q: Why would I provide free power to an AND switch?**

A: So it can be used to boost the low power output of a HBHF sensor since it only outputs 1 power per detected player.

For example, if you want to chain multiple HBHF sensors together using OR switches, the OR switches will consume all the power that the HBHF sensors are sending, rendering them effectively useless. To mitigate this, you can boost the power output of each HBHF sensor by sending its output through an AND switch that has additional power in the other input, which you can get for free with this plugin (no generator needed).

**Q: Why would I provide free power to a smart alarm?**

A: To simplify some valid circuit designs.

For example, in vanilla, you may design a circuit where the destruction of a wall or floor triggers the smart alarm, using the following wiring.

Power generator -> Electrical Branch (attached to a wall) -> Blocker ("Block Passthrough" input) -> Smart alarm

When the wall that the electrical branch is attached to is destroyed, power will resume flowing through the blocker to trigger the smart alarm. With free power to the smart alarm, you can simply place something like a switch or button on the wall, connect it to the smart alarm, and leave it always off. When that entity is destroyed with the wall, the wire will disconnect, allowing the smart alarm to start generating its own power and trigger a notification.

## Developer Hooks

Parented entities are already ignored by this plugin, so plugin conflicts are unlikely. Plugins can also block this plugin's update via the `OnInputUpdate` hook, but the `OnPowerlessInputUpdate` hook below can also be used for more granular control if needed.

#### OnPowerlessInputUpdate

```csharp
object OnPowerlessInputUpdate(IOEntity ioEntity, int inputSlot, int powerAmount)
```

- Called when this plugin is about to provide power for a particular entity's empty input slot
- Returning `false` will prevent this plugin from affecting the entity
- Returning `null` will result in the default behavior
