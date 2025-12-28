# StationpediaPlus Agent Instructions - Device Documentation

---
## ⚠️ CONDUCTOR REMINDER (for orchestrating agent)
**After each major milestone, UPDATE THE PLAN FILE:**
```
C:\Dev\12-17-25 Stationeers Respawn Update Code\plans\stationpediaplus-expansion-plan.md
```
- Update Progress Tracker table
- Update "Current Phase" and "Last Updated"
- Add notes about what was completed
---

## Your Mission

You are documenting device-specific logic descriptions for the **StationpediaPlus** mod. Your output will be used to display helpful hover tooltips in the Stationpedia UI.

## Your Batch Assignment

Check your batch file (e.g., `batch-1.txt`) for the list of devices you need to document.

## Workspace Location

```
C:\Dev\12-17-25 Stationeers Respawn Update Code\
├── Assembly-CSharp/          <- Game source code (C# classes)
├── Stationeers/Stationpedia/ <- Stationpedia.json (device metadata)
└── StationpediaPlus/         <- Mod project
    ├── mod/descriptions.json <- OUTPUT: Add your entries here
    └── coordination/         <- Batch assignments
```

## Output Format

Add entries to `StationpediaPlus/mod/descriptions.json` following this schema:

```json
{
  "deviceKey": "ThingStructureActiveVent",
  "displayName": "Active Vent",
  "logicDescriptions": {
    "On": {
      "dataType": "Boolean",
      "range": "0-1",
      "description": "Enable/disable the vent. When on, actively moves atmosphere."
    },
    "Mode": {
      "dataType": "Integer",
      "range": "0-1",
      "description": "0 = Inward (pull gas in), 1 = Outward (push gas out)."
    },
    "Setting": {
      "dataType": "Float",
      "range": "0-60795 kPa",
      "description": "Target pressure in kPa. Vent stops when reached."
    }
  },
  "slotDescriptions": {
    "Slot Name": {
      "slotType": "SlotType",
      "description": "What this slot is for."
    }
  }
}
```

## Research Process

### Step 1: Find the Device Class

1. Get the `Key` from your batch (e.g., `ThingStructureActiveVent`)
2. Search for the corresponding class file in `Assembly-CSharp/`
3. The class name often matches: `ActiveVent.cs` or search for the prefab name

### Step 2: Read Stationpedia.json

Look up the device in `Stationeers/Stationpedia/Stationpedia.json`:

```json
{
  "Key": "ThingStructureActiveVent",
  "LogicInsert": [
    { "LogicAccessTypes": "ReadWrite", "LogicSlotType": "Unknown", "LogicName": "On" },
    { "LogicAccessTypes": "ReadWrite", "LogicSlotType": "Unknown", "LogicName": "Mode" },
    { "LogicAccessTypes": "ReadWrite", "LogicSlotType": "Unknown", "LogicName": "Setting" }
  ],
  "Slots": [...]
}
```

This tells you WHAT logic types exist. Now you need to document WHAT THEY DO.

### Step 3: Analyze Source Code

Look for these methods in the device class:

```csharp
// What values can be read
public override bool CanLogicRead(LogicType logicType)

// What values can be written
public override bool CanLogicWrite(LogicType logicType)

// How read values are calculated
public override double GetLogicValue(LogicType logicType)

// How write values are applied
public override void SetLogicValue(LogicType logicType, double value)

// Slot-specific logic
public override double GetSlotLogicValue(int slotIndex, LogicSlotType logicSlotType)
```

### Step 4: Trace Inheritance

Many devices inherit from base classes. Check:
- `Device` → `DevicePowered` → `DeviceCircuit`
- `DeviceAtmospherics` → `DeviceInput` → `DeviceInputOutput`

If the parent class has logic, the child inherits it.

## Description Guidelines

### BE BRIEF (1-3 sentences max)
```
✓ "Current internal temperature in Kelvin."
✓ "0 = Idle, 1 = Smelt, 2 = Alloy, 3 = Incinerate."
✗ "This property returns the current temperature of the device's internal chamber measured in Kelvin units..."
```

### Include Mode Values
```
"Mode": {
  "description": "0 = Inward (pull), 1 = Outward (push)."
}
```

### Include Units
```
"Temperature": { "range": "0+ K", "description": "Internal temp in Kelvin." }
"Pressure": { "range": "0+ kPa", "description": "Atmospheric pressure in kPa." }
"Power": { "range": "0+ W", "description": "Current power draw in watts." }
```

### Data Types
- `Boolean` → 0/1 values (On, Lock, Open, Error)
- `Integer` → Whole numbers (Mode, Quantity, SlotCount)
- `Float` → Decimal values (Temperature, Pressure, Ratio)
- `Hash` → CRC32 prefab hashes (PrefabHash, OccupantHash)

## Slots to Document

Only add `slotDescriptions` if the device has meaningful slots. Skip generic slots like "Contents" unless context-specific.

Look at the `Slots` array in Stationpedia.json:
```json
"Slots": [
  { "SlotName": "Import", "SlotType": "Import" },
  { "SlotName": "Export", "SlotType": "Export" }
]
```

## Skip These Devices

If a device has NO logic types (empty `LogicInsert`), skip it - it doesn't need documentation.

## Working Method

1. **Work autonomously** - Don't ask for confirmation
2. **Process in order** - Go through your batch list sequentially
3. **Create one big JSON array** - Compile all your devices into one output
4. **Report when done** - Give completion status at the end

## Output Template

When done, provide your entries as a JSON array:

```json
[
  { "deviceKey": "...", "displayName": "...", "logicDescriptions": {...} },
  { "deviceKey": "...", "displayName": "...", "logicDescriptions": {...} },
  ...
]
```

The conductor will merge all batches into the final `descriptions.json`.

## Common Patterns

| Device Type | Common Logic Types |
|-------------|-------------------|
| Furnaces | Temperature, Pressure, Mode, Setting, Activate |
| Vents | On, Mode, Setting, Pressure |
| Batteries | Charge, ChargeRatio, Maximum, PowerPotential |
| Sensors | On, Setting, Mode, Activate |
| Solar Panels | Horizontal, Vertical, SolarAngle, PossibleSolarAngle |
| IC Housings | On, Error, Setting, Mode + slot logic |

## Questions?

If you encounter a device you can't figure out:
1. Note it as "NEEDS_REVIEW" in your report
2. Include what you found
3. Move on to the next device

Don't get stuck - progress is more important than perfection.

---

**START YOUR BATCH NOW. Report back when complete.**
