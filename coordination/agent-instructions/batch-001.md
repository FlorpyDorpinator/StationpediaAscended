# Batch 001: Base Classes & Logic Devices

**Status**: Ready for assignment  
**Device Count**: 13  
**Estimated Time**: ~10 minutes  
**Priority**: HIGH (base classes needed first for inheritance documentation)

## Instructions

Read the agent instructions at `coordination/templates/agent-prompt.md` first.

Document the following devices in order. Base classes should be documented FIRST since other devices inherit from them.

## Assigned Devices

### Part A: Base Classes (Document these FIRST)

| # | Device ID | Class Name | Source File |
|---|-----------|------------|-------------|
| 1 | `device-atmospherics` | DeviceAtmospherics | `Assets/Scripts/Objects/Pipes/DeviceAtmospherics.cs` |
| 2 | `device-input-output` | DeviceInputOutput | `Assets/Scripts/Objects/Pipes/DeviceInputOutput.cs` |
| 3 | `furnace-base` | FurnaceBase | `Assets/Scripts/Objects/Pipes/FurnaceBase.cs` |
| 4 | `logic-reader-base` | LogicReaderBase | `Assets/Scripts/Objects/Electrical/LogicReaderBase.cs` |
| 5 | `suit-base` | SuitBase | `Assets/Scripts/Objects/Clothing/SuitBase.cs` |

### Part B: Logic Devices (High-use devices)

| # | Device ID | Class Name | Source File |
|---|-----------|------------|-------------|
| 6 | `circuit-housing` | CircuitHousing | `Assets/Scripts/Objects/Electrical/CircuitHousing.cs` |
| 7 | `programmable-chip` | ProgrammableChip | `Assets/Scripts/Objects/Electrical/ProgrammableChip.cs` |
| 8 | `logic-memory` | LogicMemory | `Assets/Scripts/Objects/Electrical/LogicMemory.cs` |
| 9 | `logic-switch` | LogicSwitch | `Assets/Scripts/Objects/Electrical/LogicSwitch.cs` |
| 10 | `logic-button` | LogicButton | `Assets/Scripts/Objects/Electrical/LogicButton.cs` |
| 11 | `logic-dial` | LogicDial | `Assets/Scripts/Objects/Electrical/LogicDial.cs` |
| 12 | `logic-display` | LogicDisplay | `Assets/Scripts/Objects/Electrical/LogicDisplay.cs` |
| 13 | `console` | Console | `Assets/Scripts/Objects/Electrical/Console.cs` |

## Output Files

Create markdown files at:
- `StationpediaPlus/docs/wiki/devices/{device-id}.md`

## Completion Checklist

After completing all devices, create a completion report:

```
BATCH 001 COMPLETION REPORT
---------------------------
Assigned: 13 devices
Completed: X devices
Status: [COMPLETE | PARTIAL]

Files Created:
- docs/wiki/devices/device-atmospherics.md
- docs/wiki/devices/device-input-output.md
- [list all files]

Issues/Notes:
- [Any problems encountered]
```

---

**Workspace Path**: `c:\Dev\12-17-25 Stationeers Respawn Update Code\`

Work autonomously. Do not pause between devices.
