# Agent Instructions: Device Documentation

You are a documentation agent for the StationpediaPlus project. Your task is to analyze Stationeers game source code and create comprehensive device documentation.

## Your Assignment

You have been assigned a batch of devices to document. For each device:

1. **Read the source file** to understand the device's logic capabilities
2. **Create a markdown documentation file** following the template
3. **Report back** with completion status

## Workflow

### Step 1: Analyze Source Code

For each device, look for:

1. **`CanLogicRead` method** - Lists all readable LogicTypes
   ```csharp
   public override bool CanLogicRead(LogicType logicType)
   {
       if (logicType == LogicType.Temperature)
           return true;
       return base.CanLogicRead(logicType);
   }
   ```

2. **`CanLogicWrite` method** - Lists all writable LogicTypes
   ```csharp
   public override bool CanLogicWrite(LogicType logicType)
   {
       if (logicType == LogicType.Setting)
           return true;
       return base.CanLogicWrite(logicType);
   }
   ```

3. **`GetLogicValue` method** - Shows how read values are calculated
   ```csharp
   public override double GetLogicValue(LogicType logicType)
   {
       if (logicType == LogicType.Temperature)
           return this.Temperature;
       return base.GetLogicValue(logicType);
   }
   ```

4. **`SetLogicValue` method** - Shows how write values are applied
   ```csharp
   public override void SetLogicValue(LogicType logicType, double value)
   {
       if (logicType == LogicType.Setting)
           this.SettingOutput = value;
       base.SetLogicValue(logicType, value);
   }
   ```

5. **Slot logic** - Look for `CanSlotLogicRead`, `CanSlotLogicWrite`, `GetSlotLogicValue`, `SetSlotLogicValue`

6. **Reagent logic** - Look for `GetReagentLogicValue`, `SetReagentLogicValue`

### Step 2: Trace Inheritance

Many devices inherit logic from base classes. Check:
- What class does this device extend?
- Does the base class have `CanLogicRead`/`CanLogicWrite`?
- Document inherited types but note they come from parent

Common inheritance chains:
- `Device` → `DevicePowered` → `DeviceCircuit` → specialized devices
- `DeviceAtmospherics` → `DeviceInput` → `DeviceInputOutput` → furnaces/pipes
- `Thing` → `Item` → wearables, handheld items

### Step 3: Document Data Types and Ranges

For each LogicType, determine:
- **Data Type**: Boolean (0/1), Integer, Float, Hash (CRC32)
- **Range**: Min/max values, or list of valid enum values
- **Units**: Kelvin, kPa, Watts, moles, etc.

Common patterns:
- `Power`, `On`, `Open`, `Lock` → Boolean (0/1)
- `Temperature` → Float (Kelvin, typically 0-5000K)
- `Pressure` → Float (kPa, typically 0-60795 kPa)
- `Ratio` → Float (0.0-1.0)
- `Setting` → Float (device-specific range)
- `Mode` → Integer (device-specific enum)
- `PrefabHash`, `OccupantHash` → Integer (CRC32 hash)

### Step 4: Create Documentation File

Use the template at `coordination/templates/device-template.md` as your guide.

Output file path: `StationpediaPlus/docs/wiki/devices/{device-id}.md`

Where `{device-id}` is the kebab-case version (e.g., `advanced-furnace`, `air-conditioner`)

## Important Rules

1. **BE ACCURATE** - Only document logic types you can verify in the source code
2. **TRACE INHERITANCE** - Don't miss logic from parent classes
3. **NOTE SPECIAL CASES** - Some logic types are read-only or write-only
4. **INCLUDE EXAMPLES** - Add practical IC10 code snippets
5. **DOCUMENT MODES** - If Mode values exist, explain each one
6. **NO GUESSING** - If you can't determine something, mark it as "needs verification"

## Completion Report

After documenting your batch, report:

```
BATCH COMPLETION REPORT
-----------------------
Batch: {batch-id}
Devices Completed: {count}

Device Status:
- {device-id}: COMPLETE
- {device-id}: COMPLETE
- {device-id}: NEEDS_REVIEW (reason)

Files Created:
- docs/wiki/devices/{device-id}.md
- docs/wiki/devices/{device-id}.md
...

Issues Found:
- {Any problems or questions}
```

## Example Analysis

### Source: `ActiveVent.cs`

```csharp
public override bool CanLogicRead(LogicType logicType)
{
    return logicType == LogicType.On 
        || logicType == LogicType.Mode 
        || logicType == LogicType.Setting 
        || base.CanLogicRead(logicType);
}

public override bool CanLogicWrite(LogicType logicType)
{
    return logicType == LogicType.On 
        || logicType == LogicType.Mode 
        || logicType == LogicType.Setting 
        || base.CanLogicWrite(logicType);
}
```

### Result Documentation:

| LogicType | R | W | Description |
|-----------|---|---|-------------|
| `On` | ✓ | ✓ | Enable/disable the vent |
| `Mode` | ✓ | ✓ | 0=Inward, 1=Outward |
| `Setting` | ✓ | ✓ | Target pressure in kPa |
| *+inherited* | | | See DeviceAtmospherics |

---

## Your Batch Assignment

{CONDUCTOR WILL INSERT BATCH DETAILS HERE}

---

Work autonomously. Do not ask for confirmation between devices. Complete all devices in your batch before reporting back.
