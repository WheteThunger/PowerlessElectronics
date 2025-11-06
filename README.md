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
- Make sure you grant permissions for each entity that you configured with `"Require permission": true` (off by default)
- Make sure that the amount of power you configured for each entity is at least the power requirement, or there will be no effect
  - The configuration section below lists the power requirement for most entities to help you configure the plugin for your use case

## Permissions

Note: Permissions are only necessary if the corresponding entity's configuration has specified `"Require permission": true`. The default is `false` for all entities.

- `powerlesselectronics.all` -- All electrical entities deployed by players with this permission will have free power determined by the plugin configuration. You must also configure the power amount for each entity for this to have any effect.

As an alternative to the `all` permission, you can grant permissions by entity type. These are automatically generated from the plugin configuration.

- `powerlesselectronics.andswitch`
- `powerlesselectronics.audioalarm`
- `powerlesselectronics.autoturret`
- `powerlesselectronics.blocker`
- `powerlesselectronics.boombox`
- `powerlesselectronics.branch`
- `powerlesselectronics.bulbstringlights`
- `powerlesselectronics.button`
- `powerlesselectronics.cctv`
- `powerlesselectronics.ceilinglight`
- `powerlesselectronics.chandelier`
- `powerlesselectronics.combiner`
- `powerlesselectronics.counter`
- `powerlesselectronics.digitalclock`
- `powerlesselectronics.discoball`
- `powerlesselectronics.discofloor.largetiles`
- `powerlesselectronics.discofloor`
- `powerlesselectronics.doorcontroller`
- `powerlesselectronics.electricfurnace.io`
- `powerlesselectronics.elevatorioentity`
- `powerlesselectronics.fairylights`
- `powerlesselectronics.flasherlight`
- `powerlesselectronics.fluidswitch`
- `powerlesselectronics.fluorescentlight.ceiling`
- `powerlesselectronics.fluorescentlight`
- `powerlesselectronics.fridge`
- `powerlesselectronics.hbhfsensor`
- `powerlesselectronics.heater`
- `powerlesselectronics.hopper`
- `powerlesselectronics.igniter`
- `powerlesselectronics.industrial.wall.lamp.blue`
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
- `powerlesselectronics.minifridge`
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
- `powerlesselectronics.sculpture.ice`
- `powerlesselectronics.searchlight`
- `powerlesselectronics.seismicsensor`
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
- `powerlesselectronics.spotlight.tripod`
- `powerlesselectronics.spotlight`
- `powerlesselectronics.storageadaptor.deployed`
- `powerlesselectronics.storagemonitor`
- `powerlesselectronics.switch`
- `powerlesselectronics.tablelamp`
- `powerlesselectronics.telephone`
- `powerlesselectronics.teslacoil`
- `powerlesselectronics.timer`
- `powerlesselectronics.vendingmachine`
- `powerlesselectronics.wallcabinet`
- `powerlesselectronics.water.pump`
- `powerlesselectronics.weaponracklight`
- `powerlesselectronics.weaponracklightdouble`
- `powerlesselectronics.xmas.advanced.lights`
- `powerlesselectronics.xorswitch`

## Configuration

Default configuration (no entities provide free power):

```json
{
  "Add switch to powerless auto turrets": false,
  "Add switch to powerless SAM sites": false,
  "Entities": {
    "andswitch.entity": {
      "Require permission": false,
      "Input slots": [
        0,
        1
      ],
      "Generate power amounts": [
        0,
        0
      ]
    },
    "audioalarm": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "autoturret_deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "boombox.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "button": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "cctv_deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "ceilinglight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "counter": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "discoball.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "discofloor.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "discofloor.largetiles.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "doorcontroller.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.bulbstringlights.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.chandelier.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.digitalclock.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.fairylights.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.flasherlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.fluorescentlight.ceiling.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.fluorescentlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.seismicsensor.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.sirenlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.spotlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.spotlight.tripod.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.tablelamp.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electric.wallcabinet.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.blocker.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.branch.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.combiner.deployed": {
      "Require permission": false,
      "Input slots": [
        0,
        1
      ],
      "Generate power amounts": [
        0,
        0
      ]
    },
    "electrical.heater": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.memorycell.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.modularcarlift.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electrical.random.switch.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "electricfurnace.io": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "elevator": {
      "Require permission": false,
      "Input slots": [
        2
      ],
      "Generate power amount": 0
    },
    "fluidswitch": {
      "Require permission": false,
      "Input slots": [
        2
      ],
      "Generate power amount": 0
    },
    "fridge.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "hbhfsensor.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "hopper.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "igniter.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "industrial.wall.lamp.blue.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "industrial.wall.lamp.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "industrial.wall.lamp.green.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "industrial.wall.lamp.red.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "industrialconveyor.deployed": {
      "Require permission": false,
      "Input slots": [
        1
      ],
      "Generate power amount": 0
    },
    "industrialcrafter.deployed": {
      "Require permission": false,
      "Input slots": [
        1
      ],
      "Generate power amount": 0
    },
    "large.rechargable.battery.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "laserdetector": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "laserlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "medium.rechargable.battery.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "microphonestandio.entity": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "minifridge.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "orswitch.entity": {
      "Require permission": false,
      "Input slots": [
        0,
        1
      ],
      "Generate power amounts": [
        0,
        0
      ]
    },
    "poweredwaterpurifier.deployed": {
      "Require permission": false,
      "Input slots": [
        1
      ],
      "Generate power amount": 0
    },
    "pressurepad.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "ptz_cctv_deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "reactivetarget_deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "rfbroadcaster": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "rfreceiver": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sam_site_turret_deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sculpture.ice.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "searchlight.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sign.neon.125x125": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sign.neon.125x215": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sign.neon.125x215.animated": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sign.neon.xl": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "sign.neon.xl.animated": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "simplelight": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "smallrechargablebattery.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "smartalarm": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "smartswitch": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "splitter": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "storageadaptor.deployed": {
      "Require permission": false,
      "Generate power amount": 0,
      "Input slots": [
        1
      ]
    },
    "storagemonitor.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "switch": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "telephone.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "teslacoil.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "timer": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "vendingmachine.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "water.pump.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "weaponracklight": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "weaponracklightdouble": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "xmas.advanced.lights.deployed": {
      "Require permission": false,
      "Generate power amount": 0
    },
    "xorswitch.entity": {
      "Require permission": false,
      "Input slots": [
        0,
        1
      ],
      "Generate power amounts": [
        0,
        0
      ]
    }
  }
}
```

- `Add switch to powerless auto turrets` (`true` or `false`) -- While `true`, a switch will be added to auto turrets that are configured to generate their own power, allowing players to turn the turret on or off. Note that the switch will be temporarily hidden while the turret has a wire connected to its power input.
- `Add switch to powerless SAM sites` (`true` or `false`) -- While `true`, a switch will be added to SAM sites that are configured to generate their own power, allowing players to turn the SAM site on or off. Note that the switch will be temporarily hidden while the SAM site has a wire connected to its power input.

Each entity type has the following configuration options, mapped in the config to the entity's prefab short name.

- `Require permission` (`true` or `false`) -- While `true`, only entities of this type that were deployed by players with the corresponding permission will receive the power configured here. While `false`, all entities of this type will have the power configured here.
- `Generate power amount` -- Amount of power to provide to each input where a wire is missing.
- `Generate power amounts` -- List of power amounts, applicable when the entity has multiple power inputs. You can also use the `Generate power amount` (singular) option to apply the same amount to all inputs.
- `Input slots` (Advanced) -- You should only need to configure this option if you want to provide free power for an entity that is not yet in the plugin's default configuration, such as when new items are introduced to the game. This option controls which internal slot numbers to assign power to. Most entities only have one power input which is usually at slot `0`, but some have multiple or use different numbers due to also having water inputs.

Note: This plugin ignores any input slot which is configured with `0` power, so it will not interfere with other plugins that provide powerless functionality. The only gotcha is that if you provided free power to an entity via this plugin and then changed the configuration to provide `0` power, the entity will have free power until a wire is connected to that input, or until the next server restart.

### Entity power requirements

To help you configure the plugin for your use case, the minimum amount of useful power for each entity is listed below. These may be a little higher than the power requirement since some entities are effectively useless without providing extra power for the outputs. I have added a + for entities where adding more power provides a useful function besides simple passthrough.

- `andswitch.entity`: 2+, 2+
- `audioalarm`: 1
- `autoturret_deployed`: 10+
- `boombox.deployed`: 1+
- `button`: 2+
- `cctv_deployed`: 3
- `ceilinglight.deployed`: 2
- `counter`: 1+
- `discoball.deployed`: 1+
- `discofloor.deployed`: 1+
- `discofloor.largetiles.deployed`: 1+
- `doorcontroller.deployed`: 1+
- `electric.bulbstringlights.deployed`: 5
- `electric.chandelier.deployed`: 4
- `electric.digitalclock.deployed`: 1
- `electric.fairylights.deployed`: 5
- `electric.flasherlight.deployed`: 1
- `electric.fluorescentlight.ceiling.deployed`: 2
- `electric.fluorescentlight.deployed`: 1
- `electric.seismicsensor.deployed`: 1+
- `electric.sirenlight.deployed`: 1
- `electric.spotlight.deployed`: 5
- `electric.spotlight.tripod.deployed`: 5
- `electric.tablelamp.deployed`: 1
- `electric.wallcabinet.deployed`: 1
- `electrical.blocker.deployed`: 2+
- `electrical.branch.deployed`: 4+
- `electrical.combiner.deployed`: 1+, 1+
- `electrical.heater`: 3
- `electrical.memorycell.deployed`: 1+
- `electrical.modularcarlift.deployed`: 5
- `electrical.random.switch.deployed`: 2+
- `electricfurnace.io`: 3
- `elevator`: 5
- `fluidswitch`: 1
- `fridge.deployed`: 5
- `hbhfsensor.deployed`: 2+
- `hopper`: 8
- `igniter.deployed`: 2
- `industrial.wall.lamp.blue.deployed`: 1
- `industrial.wall.lamp.deployed`: 1
- `industrial.wall.lamp.green.deployed`: 1
- `industrial.wall.lamp.red.deployed`: 1
- `industrialconveyor.deployed`: 1
- `industrialcrafter.deployed`: 1
- `laserdetector`: 2+
- `laserlight.deployed`: 1+
- `microphonestandio`: 1+
- `minifridge.deployed`: 2
- `orswitch.entity`: 2+, 2+
- `poweredwaterpurifier.deployed`: 5
- `pressurepad.deployed`: 2+
- `ptz_cctv_deployed`: 3
- `reactivetarget_deployed`: 2+
- `rfbroadcaster`: 1
- `rfreceiver`: 2+
- `sam_site_turret_deployed`: 25
- `sculpture.ice.deployed`: 1
- `searchlight.deployed`: 10
- `sign.neon.125x125`: 4
- `sign.neon.125x215.animated`: 10
- `sign.neon.125x215`: 6
- `sign.neon.xl.animated`: 15
- `sign.neon.xl`: 8
- `simplelight`: 1
- `smartalarm`: 1
- `smartswitch`: 2+
- `splitter`: 4+
- `storagemonitor.deployed`: 1+
- `storageadaptor.deployed`: 1
- `switch`: 2+
- `telephone.deployed`: 1+
- `teslacoil.deployed`: 1-35
- `timer`: 2+
- `vendingmachine.deployed`: 5
- `water.pump.deployed`: 5
- `weaponracklight`: 1
- `weaponracklightdouble`: 1
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
