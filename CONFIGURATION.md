# Stationpedia Ascended - Configuration Guide

This document explains all the configuration options available in the `descriptions.json` file.

## File Structure Overview

```json
{
  "genericDescriptions": { ... },
  "devices": [ ... ]
}
```

---

## Generic Descriptions

Generic descriptions provide tooltips for common logic types, slots, modes, etc. that apply across many devices. These are used as fallbacks when a device doesn't have a specific description defined.

### `genericDescriptions.logic`

Tooltip descriptions for logic variable types that appear on any device.

```json
"logic": {
  "Power": "Returns 1 if device is receiving power.",
  "On": "Device on/off state. Can be set via logic.",
  "Temperature": "Internal temperature in Kelvin.",
  "Setting": "Device-specific setting value."
}
```

**Usage**: When you hover over a logic type in the Stationpedia, this description appears as a tooltip.

---

### `genericDescriptions.slots`

Descriptions for slot logic types (used with `sl` and `ls` IC10 commands).

```json
"slots": {
  "Occupied": "Returns 1 if slot contains an item, 0 if empty.",
  "OccupantHash": "PrefabHash of item in slot, or 0 if empty.",
  "Quantity": "Stack quantity of item in slot.",
  "Damage": "Damage level of item in slot (0=pristine, 1=destroyed).",
  "Charge": "Charge level of battery/cell in slot."
}
```

---

### `genericDescriptions.modes`

Descriptions for numbered mode values.

```json
"modes": {
  "0": "Device disabled/off state",
  "1": "Standard operational mode"
}
```

---

### `genericDescriptions.versions`

Descriptions for printer/fabricator tier versions.

```json
"versions": {
  "Tier One": "Base manufacturing tier. Standard speed and efficiency.",
  "Tier Two": "Upgraded tier. Unlocks additional recipes.",
  "Tier Three": "Advanced tier. Highest capability."
}
```

---

### `genericDescriptions.connections`

Descriptions for connection types shown on device pages.

```json
"connections": {
  "Power": "Electrical power delivery system",
  "Data": "Digital communication channel",
  "Chute": "Item transportation connection"
}
```

---

### `genericDescriptions.memory`

Detailed descriptions for memory stack instructions (used in Sorter, Avionics, Trader).

```json
"memory": {
  "SorterInstruction.FilterByPrefabHash": {
    "opCode": "SorterInstruction.FilterByPrefabHash",
    "parameters": "Condition_Operation (enum), PrefabHash (int)",
    "description": "Filters items by their PrefabHash using comparison.",
    "byteLayout": "0-7: OP_CODE (BYTE_8)\n8-15: Condition_Operation\n16-47: PrefabHash (INT_32)"
  }
}
```

---

## Device Entries

The `devices` array contains device-specific configurations that override generic descriptions.

### Basic Device Entry

```json
{
  "deviceKey": "StructureLogicWriter",
  "displayName": "Logic Writer",
  "logicDescriptions": { ... },
  "modeDescriptions": { ... },
  "slotDescriptions": { ... },
  "operationalDetails": [ ... ]
}
```

---

### Device Fields Reference

| Field | Type | Description |
|-------|------|-------------|
| `deviceKey` | string | **Required**. The internal page key (e.g., `ThingSolarPanel`, `StructureLogicWriter`). Must match the Stationpedia page key exactly. |
| `displayName` | string | Optional friendly name for logging/debugging. |
| `pageDescription` | string | **Replaces** the entire page description with this text. |
| `pageDescriptionAppend` | string | **Appends** text after the existing page description. |
| `pageDescriptionPrepend` | string | **Prepends** text before the existing page description. |
| `operationalDetails` | array | Shows a collapsible "Operational Details" section at the top of the page. |
| `operationalDetailsTitleColor` | string | Hex color for the "Operational Details" title (default: `#FF7A18`). |
| `logicDescriptions` | object | Device-specific logic variable descriptions (override generics). |
| `modeDescriptions` | object | Named mode descriptions for this device. |
| `slotDescriptions` | object | Descriptions for specific slots on this device. |
| `versionDescriptions` | object | Tier/version descriptions for printers/fabricators. |
| `memoryDescriptions` | object | Memory instruction descriptions (for devices with memory stacks). |

---

## Page Description Hooks

### Replace Entire Description

```json
{
  "deviceKey": "ThingSolarPanel",
  "pageDescription": "This completely replaces the original description text."
}
```

### Append to Description

```json
{
  "deviceKey": "ThingSolarPanel",
  "pageDescriptionAppend": "\n\n**Note:** This text appears after the original description."
}
```

### Prepend to Description

```json
{
  "deviceKey": "ThingSolarPanel",
  "pageDescriptionPrepend": "⚠️ **Important:** This text appears before the original description.\n\n"
}
```

**Priority**: If `pageDescription` is set, it takes priority and `append`/`prepend` are ignored.

---

## Operational Details Section

The Operational Details section creates a collapsible category at the top of device pages for important operational information.

### Structure

```json
{
  "deviceKey": "ItemRobotAimee",
  "operationalDetails": [
    {
      "title": "IC10 Execution",
      "description": "Executes up to 128 IC10 instructions per tick when powered."
    },
    {
      "title": "Power Consumption",
      "description": "Idle: 5W. Moving: +10W per motor power level."
    }
  ],
  "operationalDetailsTitleColor": "#FF7A18"
}
```

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `title` | string | Bold header for this detail item |
| `description` | string | The detail text (supports basic formatting) |

### Color Customization

```json
"operationalDetailsTitleColor": "#FFD700"  // Gold color
"operationalDetailsTitleColor": "#00FF00"  // Green color
"operationalDetailsTitleColor": "#FF7A18"  // Default orange
```

---

## Logic Descriptions

Override or supplement generic logic descriptions for specific devices.

### Basic Format

```json
"logicDescriptions": {
  "Setting": {
    "dataType": "Float",
    "range": "0-100",
    "description": "Target pressure setpoint in kPa."
  },
  "Mode": {
    "dataType": "Integer",
    "range": "0-3",
    "description": "Operating mode: 0=Off, 1=Inward, 2=Outward, 3=Both"
  }
}
```

### Fields

| Field | Type | Description |
|-------|------|-------------|
| `dataType` | string | Data type (Boolean, Integer, Float, Hash) |
| `range` | string | Valid value range (e.g., "0-1", "0-100", "Unique") |
| `description` | string | What this logic type does on this specific device |
| `access` | string | Optional: "Read", "Write", or "Read Write" |

---

## Mode Descriptions

Named descriptions for each mode value on a device.

```json
"modeDescriptions": {
  "None": {
    "modeValue": "0",
    "description": "Robot is idle and awaiting commands."
  },
  "Follow": {
    "modeValue": "1",
    "description": "Robot follows the nearest player."
  },
  "MoveToTarget": {
    "modeValue": "2",
    "description": "Robot moves to TargetX/Y/Z coordinates."
  }
}
```

---

## Slot Descriptions

Descriptions for specific slots on a device.

```json
"slotDescriptions": {
  "0": {
    "slotType": "ProgrammableChip",
    "description": "IC10 chip slot for programming custom logic."
  },
  "1": {
    "slotType": "Battery",
    "description": "Power cell slot. Accepts any battery type."
  }
}
```

---

## Memory Descriptions

For devices with memory stacks (Sorter, Avionics, Trader).

```json
"memoryDescriptions": {
  "SorterInstruction.FilterByPrefabHash": {
    "opCode": "SorterInstruction.FilterByPrefabHash",
    "parameters": "Condition_Operation (enum), PrefabHash (int)",
    "description": "Filters items by their PrefabHash.",
    "byteLayout": "0-7: OP_CODE\n8-15: Condition\n16-47: Hash"
  }
}
```

---

## Complete Device Example

```json
{
  "deviceKey": "StructureActiveVent",
  "displayName": "Active Vent",
  "pageDescriptionAppend": "\n\n**Tip:** Use two vents with opposite modes for bidirectional flow.",
  "operationalDetails": [
    {
      "title": "Pressure Equalization",
      "description": "The vent attempts to equalize pressure between internal and external atmospheres at a rate determined by the pressure differential."
    },
    {
      "title": "Power Scaling",
      "description": "Power consumption scales with flow rate. Idle: 5W, Max flow: 50W."
    }
  ],
  "operationalDetailsTitleColor": "#4A90D9",
  "logicDescriptions": {
    "Setting": {
      "dataType": "Float",
      "range": "0-101325",
      "description": "Target pressure in Pascals. Vent operates until this pressure is reached."
    },
    "Mode": {
      "dataType": "Integer",
      "range": "0-2",
      "description": "0=Off, 1=Inward (pull gas in), 2=Outward (push gas out)"
    }
  },
  "modeDescriptions": {
    "Inward": {
      "modeValue": "1",
      "description": "Pulls external atmosphere into the pipe network."
    },
    "Outward": {
      "modeValue": "2",
      "description": "Pushes pipe contents into the external atmosphere."
    }
  }
}
```

---

## Finding Device Keys

To find the correct `deviceKey` for a device:

1. Open the Stationpedia in-game
2. Navigate to the device page
3. Check the console logs - the mod prints the page key
4. Or use IC10 `PrefabHash` and look up the hash in game files

Common patterns:
- Structures: `StructureXxx` (e.g., `StructureLogicWriter`)
- Items: `ItemXxx` (e.g., `ItemTablet`)
- Things: `ThingXxx` (e.g., `ThingSolarPanel`)

---

## Tips & Best Practices

1. **Test incrementally** - Add one device at a time and reload to verify
2. **Use F6 hot-reload** - Changes take effect without restarting the game
3. **Check console for errors** - JSON parsing errors are logged
4. **Keep descriptions concise** - Tooltips work best with 1-2 sentences
5. **Use Operational Details sparingly** - Only for complex behaviors not obvious from the UI

---

## JSON Validation

Before saving, validate your JSON at [jsonlint.com](https://jsonlint.com) or use VS Code's built-in JSON validation.

Common issues:
- Missing commas between entries
- Trailing commas (not allowed in JSON)
- Unescaped quotes in strings (use `\"`)
- Mismatched brackets
