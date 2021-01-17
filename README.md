## Features

- Allow any electrical entity to generate its own power
- Configure power amount for each entity type and input separately
- Optionally require permissions, on a per entity basis with separate permissions for each
- Designed to work with circuits, so inputs with a wire in them are ignored
  - As soon as an input wire is disconnected, power magically starts flowing in its place

## Permissions

Note: Permissions are only necessary if the corresponding entity's configuration has specified `"RequirePermission": true`. The default is `false` for all entities, meaning permissions are not required until you change that.

- `powerlesselectronics.all` -- All electrical entities deployed by players with this permission will have free power determined by the plugin configuration. You must also configure the power amount for each entity for this to have any effect.

As an alternative to the `all` permission, you can grant permissions by entity type. These are automatically generated from the plugin configuration.

- `powerlesselectronics.andswitch`
- `powerlesselectronics.audioalarm`
- `powerlesselectronics.autoturret`
- `powerlesselectronics.button`
- `powerlesselectronics.cctv`
- `powerlesselectronics.ceilinglight`
- `powerlesselectronics.counter`
- `powerlesselectronics.doorcontroller`
- `powerlesselectronics.flasherlight`
- `powerlesselectronics.sirenlight`
- `powerlesselectronics.blocker`
- `powerlesselectronics.branch`
- `powerlesselectronics.combiner`
- `powerlesselectronics.heater`
- `powerlesselectronics.memorycell`
- `powerlesselectronics.modularcarlift`
- `powerlesselectronics.random.switch`
- `powerlesselectronics.elevatorioentity`
- `powerlesselectronics.fluidswitch`
- `powerlesselectronics.hbhfsensor`
- `powerlesselectronics.igniter`
- `powerlesselectronics.laserdetector`
- `powerlesselectronics.large.rechargable.battery`
- `powerlesselectronics.medium.rechargable.battery`
- `powerlesselectronics.orswitch`
- `powerlesselectronics.poweredwaterpurifier`
- `powerlesselectronics.pressurepad`
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
    "laserdetector": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "large.rechargable.battery.deployed": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "medium.rechargable.battery.deployed": {
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
    "sign.neon.125x215.animated": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.125x215": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.xl.animated": {
      "RequirePermission": false,
      "PowerAmount": 0
    },
    "sign.neon.xl": {
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

- `Entities` -- Each entity has a separate configuration, based on the prefab short name.
  - `RequirePermission` (`true` or `false`) -- While `true`, only entities of this type that were deployed by players with the corresponding permission will receive the power configured here. While `false`, all entities of this type will have the power configured here.
  - `PowerAmount` -- Amount of power to provide to each input where a wire is missing.
  - `PowerAmounts` -- List of power amounts, applicable when the entity has multiple power inputs. You can also use the `PowerAmount` (singular) option to apply the same amount to all inputs.
  - `InputSlots` (Advanced) -- You can probably ignore this option. The game assigns internal slot numbers to differentiate each power input. Mosts entities only have one power input which is usually at slot `0`, but some have multiple or use different numbers due to also having water inputs. You should only need to change this option if you want to configure an entity that is not yet in the plugin's default configuration, such as when new items are introduced to the game.

### Entity power requirements

Power requirements are listed below for your convenience. Be sure to visit the [Rust Labs website](https://rustlabs.com) for the most up-to-date information. Keep in mind that the numbers I have provided below may be a little higher than the actual electricity cost of some entities because they are effectively useless without providing extra power for the outputs, so think of these as the practical minimums. I have added a + for entities where adding more power provides a useful function besides simple passthrough.

- `andswitch.entity` -- 2+, 2+
- `audioalarm` -- 1
- `autoturret_deployed` -- 10+
- `button` -- 2+
- `cctv_deployed` -- 5
- `ceilinglight.deployed` -- 2
- `counter` -- 1+
- `doorcontroller.deployed` -- 1+
- `electric.flasherlight.deployed` -- 1
- `electric.sirenlight.deployed` -- 1
- `electrical.blocker.deployed` -- 2+
- `electrical.branch.deployed` -- 4+
- `electrical.combiner.deployed` -- 1+, 1+
- `electrical.heater` -- 3
- `electrical.memorycell.deployed` -- 1+
- `electrical.modularcarlift.deployed` -- 5
- `electrical.random.switch.deployed` -- 2+
- `elevatorioentity` -- 5
- `fluidswitch` -- 0-1
- `hbhfsensor.deployed` -- 1
- `igniter.deployed` -- 2
- `laserdetector` -- 2+
- `orswitch.entity` -- 2+, 2+
- `poweredwaterpurifier.deployed` -- 5
- `pressurepad.deployed` -- 2+
- `reactivetarget_deployed` -- 2+
- `rfbroadcaster` -- 1
- `rfreceiver` -- 2+
- `sam_site_turret_deployed` -- 25
- `searchlight.deployed` -- 10
- `sign.neon.125x125` -- 4
- `sign.neon.125x215.animated` - 10
- `sign.neon.125x215` -- 6
- `sign.neon.xl.animated` - 15
- `sign.neon.xl` -- 8
- `simplelight` -- 1
- `smartalarm` -- 1+
- `smartswitch` -- 2+
- `splitter` -- 4+
- `storagemonitor.deployed` -- 1+
- `switch` -- 2+
- `telephone.deployed` -- 1+
- `teslacoil.deployed` -- 1-35
- `timer` -- 2+
- `water.pump.deployed` -- 5
- `xmas.advanced.lights.deployed` -- 5
- `xorswitch.entity` -- 1+

## Developer Hooks

Parented entities are already ignored by this plugin, so plugin conflicts are unlikely. Plugins can also block this plugin's update via the `OnInputUpdate` hook, but the `OnPowerlessInputUpdate` hook below can also be used for more granular control if needed.

#### OnPowerlessInputUpdate

- Called when this plugin is about to add or remove power for a particular entity's input slot
- Returning `false` will prevent this plugin from affecting the entity
- Returning `null` will result in the default behavior

```csharp
object OnPowerlessInputUpdate(IOEntity ioEntity, int inputSlot, int powerAmount)
```