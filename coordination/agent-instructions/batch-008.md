# Batch 008: Remaining Devices & Base Classes

**Status**: Ready for assignment  
**Device Count**: 16  
**Estimated Time**: ~12 minutes  
**Priority**: LOW (misc remaining devices)

## Instructions

Read the agent instructions at `coordination/templates/agent-prompt.md` first.

## Assigned Devices

### Base Classes

| # | Device ID | Class Name | Source File |
|---|-----------|------------|-------------|
| 1 | `device-import` | DeviceImport | `Assets/Scripts/Objects/Pipes/DeviceImport.cs` |
| 2 | `device-import-export` | DeviceImportExport | `Assets/Scripts/Objects/Pipes/DeviceImportExport.cs` |
| 3 | `device-input` | DeviceInput | `Assets/Scripts/Objects/Pipes/DeviceInput.cs` |
| 4 | `device-input-output-import` | DeviceInputOutputImport | `Assets/Scripts/Objects/Pipes/DeviceInputOutputImport.cs` |
| 5 | `device-input-output-import-export` | DeviceInputOutputImportExport | `Assets/Scripts/Objects/Pipes/DeviceInputOutputImportExport.cs` |
| 6 | `device-output` | DeviceOutput | `Assets/Scripts/Objects/Pipes/DeviceOutput.cs` |

### Audio & Misc Devices

| # | Device ID | Class Name | Source File |
|---|-----------|------------|-------------|
| 7 | `speaker` | Speaker | `Assets/Scripts/Objects/Electrical/Speaker.cs` |
| 8 | `passive-speaker` | PassiveSpeaker | `Assets/Scripts/Objects/Electrical/PassiveSpeaker.cs` |
| 9 | `audio-sequencer` | AudioSequencer | `Objects/Electrical/AudioSequencer.cs` |
| 10 | `lfo-volume` | LfoVolume | `Assets/Scripts/Objects/Electrical/LfoVolume.cs` |
| 11 | `basket-hoop` | BasketHoop | `Assets/Scripts/Objects/Electrical/BasketHoop.cs` |
| 12 | `spawn-point-atmospherics` | SpawnPointAtmospherics | `Assets/Scripts/Objects/Electrical/SpawnPointAtmospherics.cs` |
| 13 | `advanced-composter` | AdvancedComposter | `Objects/Electrical/AdvancedComposter.cs` |
| 14 | `power-generator-pipe` | PowerGeneratorPipe | `Assets/Scripts/Objects/Electrical/PowerGeneratorPipe.cs` |

## Note: Pre-existing Documentation

The following devices already have draft documentation and should be SKIPPED:
- `advanced-furnace` - Already documented
- `aimee` - Already documented  
- `filtration-machine` - Already documented

## Output Files

Create markdown files at:
- `StationpediaPlus/docs/wiki/devices/{device-id}.md`

## Completion Checklist

After completing all devices, create a completion report:

```
BATCH 008 COMPLETION REPORT
---------------------------
Assigned: 14 devices
Completed: X devices
Status: [COMPLETE | PARTIAL]

Files Created:
- docs/wiki/devices/device-import.md
- [list all files]

Issues/Notes:
- [Any problems encountered]
```

---

**Workspace Path**: `c:\Dev\12-17-25 Stationeers Respawn Update Code\`

Work autonomously. Do not pause between devices.
