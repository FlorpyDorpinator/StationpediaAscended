# ⚠️ AGENTS: Save Your Work to Your Batch File

## IMPORTANT: Before you finish, save your device entries!

### Your Output File

Save your JSON array to your batch output file:

| Agent | Output File |
|-------|-------------|
| Agent 1 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-1-output.json` |
| Agent 2 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-2-output.json` |
| Agent 3 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-3-output.json` |
| Agent 4 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-4-output.json` |
| Agent 5 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-5-output.json` |
| Agent 6 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-6-output.json` |
| Agent 7 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-7-output.json` |
| Agent 8 | `C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-8-output.json` |

### Required Format

Your output file must be a valid JSON array of device objects:

```json
[
  {
    "deviceKey": "ThingStructureActiveVent",
    "displayName": "Active Vent",
    "logicDescriptions": {
      "On": {
        "dataType": "Boolean",
        "range": "0-1",
        "description": "Enable/disable the vent."
      },
      "Mode": {
        "dataType": "Integer",
        "range": "0-1",
        "description": "0 = Inward, 1 = Outward."
      }
    }
  },
  {
    "deviceKey": "ThingStructureAirConditioner",
    "displayName": "Air Conditioner",
    "logicDescriptions": {
      "On": {
        "dataType": "Boolean",
        "range": "0-1", 
        "description": "Power state."
      }
    }
  }
]
```

### How to Save

Use the `create_file` tool to write your complete JSON array:

```
create_file(
  filePath: "C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-{N}-output.json",
  content: <your JSON array>
)
```

### Checklist Before Finishing

- [ ] All devices from your batch are included
- [ ] JSON is valid (proper commas, brackets, quotes)
- [ ] Each device has `deviceKey`, `displayName`, and `logicDescriptions`
- [ ] File is saved to the correct `batch-{N}-output.json` path

---

**DO THIS NOW** if you haven't already saved your work!
