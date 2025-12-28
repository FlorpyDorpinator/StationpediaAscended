# Agent Review Instructions: Verify & Complete Device Logic Types

## Your Mission

Your previous batch has TWO critical issues that need fixing:

1. **MISSING logic types** - You only documented a subset of each device's logic types
2. **INACCURATE descriptions** - Device-specific types (Mode, Setting, etc.) may be hallucinated

You must:
1. Add ALL missing logic types from Stationpedia
2. Verify device-specific types against actual source code

---

## ISSUE 1: Missing Logic Types

Your batch output is missing many logic types that exist in Stationpedia.json.

### How to Find Missing Types

1. Load your batch output from `coordination/outputs/batch-{N}-output.json`
2. For each device, check `Stationeers/Stationpedia/Stationpedia.json` for its `LogicInsert` array
3. Compare what you documented vs what Stationpedia lists
4. Add entries for ALL missing types

### Pre-Generated Missing List

Check `coordination/outputs/missing-logic-types.json` for a list of all devices with missing types.

### Adding Missing Types

For generic types (same meaning everywhere), use these standard descriptions:

```json
"Power": { "dataType": "Boolean", "range": "0-1", "description": "Returns 1 if device is powered." },
"On": { "dataType": "Boolean", "range": "0-1", "description": "Device on/off state." },
"RequiredPower": { "dataType": "Float", "range": "0+ W", "description": "Power draw in watts." },
"Temperature": { "dataType": "Float", "range": "0+ K", "description": "Temperature in Kelvin." },
"Pressure": { "dataType": "Float", "range": "0+ kPa", "description": "Pressure in kPa." },
"Open": { "dataType": "Boolean", "range": "0-1", "description": "Whether device is open." },
"ReferenceId": { "dataType": "Hash", "range": "Unique", "description": "Unique reference ID." },
"PrefabHash": { "dataType": "Hash", "range": "CRC32", "description": "Device type hash." },
"NameHash": { "dataType": "Hash", "range": "CRC32", "description": "Custom name hash." },
"TotalMoles": { "dataType": "Float", "range": "0+", "description": "Total gas moles in device." },
"Combustion": { "dataType": "Boolean", "range": "0-1", "description": "Whether combustion is occurring." }
```

For gas ratio types, use this pattern:
```json
"RatioOxygen": { "dataType": "Float", "range": "0-1", "description": "Oxygen ratio in internal atmosphere." },
"RatioOxygenInput": { "dataType": "Float", "range": "0-1", "description": "Oxygen ratio at input." },
"RatioOxygenOutput": { "dataType": "Float", "range": "0-1", "description": "Oxygen ratio at output." }
```

Same pattern for: Nitrogen, CarbonDioxide, Volatiles, Water, Pollutant, NitrousOxide, Hydrogen, Steam, and their Liquid variants.

---

## ISSUE 2: Inaccurate Device-Specific Descriptions

## Logic Types That MUST Be Verified

These types have **different meanings per device** - you CANNOT guess:

| Logic Type | Why It Varies |
|------------|---------------|
| `Mode` | Different enums per device (BatteryCellState, VentMode, FurnaceMode, etc.) |
| `Setting` | Device-specific purpose (temperature, pressure, ratio, watts, etc.) |
| `Ratio` | What ratio? (charge ratio, fill ratio, progress ratio, etc.) |
| `Error` | What conditions trigger error? |
| `Lock` | What does locking do for THIS device? |
| `Activate` | What does activation trigger? |
| `Output` / `Output2` | What value is being output? |
| `Input` / `Input2` | What value is being input? |
| `CombustionInput` / `CombustionInput2` / `CombustionOutput` / `CombustionOutput2` | Combustion-specific values |

## Verification Process

### Step 1: Find Your Batch Output File

Your batch output is at:
```
C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\coordination\outputs\batch-{N}-output.json
```

### Step 2: For Each Device, Find the Source Class

1. Take the deviceKey (e.g., `ThingStructureBatteryLarge`)
2. Search for the class in `Assembly-CSharp/` folder
3. The class is usually named like `Battery.cs`, `ActiveVent.cs`, etc.

### Step 3: Find These Methods in Source Code

```csharp
// Check what Mode values mean
public override string[] ModeStrings { get; }  // Often references an enum

// Check how values are read
public override double GetLogicValue(LogicType logicType)
{
    if (logicType == LogicType.Mode)
        return (double)this._someState;  // <-- What is this?
}

// Check what Setting does
public override void SetLogicValue(LogicType logicType, double value)
{
    if (logicType == LogicType.Setting)
        this.TargetPressure = value;  // <-- What property does it set?
}
```

### Step 4: Look Up Enums

If Mode uses an enum, find it:
```csharp
// Example: Battery uses BatteryCellState
public enum BatteryCellState { Empty, Critical, VeryLow, Low, Medium, High, Full }
```

### Step 5: Update Your Descriptions

Fix any wrong descriptions. Example correction:

**WRONG (hallucinated):**
```json
"Mode": {
  "description": "0 = Auto, 1 = Prioritize Charging."
}
```

**CORRECT (from source code):**
```json
"Mode": {
  "description": "Read-only charge state: 0=Empty, 1=Critical, 2=VeryLow, 3=Low, 4=Medium, 5=High, 6=Full."
}
```

## Red Flags - Descriptions That Are Probably Wrong

Watch for these patterns that suggest hallucination:

- "0 = Auto, 1 = Manual" (generic guess)
- "0 = Off, 1 = On" for Mode (that's `On`, not `Mode`)
- "Target value" without saying target of WHAT
- "Sets the device setting" (circular, meaningless)
- Any Mode description with only 2 values (most have 3+)

## Output Format

Create an **amendments file** with ALL changes (fixes AND additions):

```json
[
  {
    "deviceKey": "ThingStructureBatteryLarge",
    "amendments": {
      "Mode": {
        "action": "fix",
        "dataType": "Integer",
        "range": "0-6",
        "description": "Read-only charge state: 0=Empty, 1=Critical, 2=VeryLow, 3=Low, 4=Medium, 5=High, 6=Full."
      },
      "Power": {
        "action": "add",
        "dataType": "Boolean",
        "range": "0-1",
        "description": "Returns 1 if battery has charge."
      },
      "ReferenceId": {
        "action": "add",
        "dataType": "Hash",
        "range": "Unique",
        "description": "Unique reference ID."
      }
    },
    "notes": "Mode is read-only. Added 2 missing types."
  }
]
```

**Action values:**
- `"fix"` - Correcting an existing wrong description
- `"add"` - Adding a missing logic type

Save to: `coordination/outputs/batch-{N}-amendments.json`

---

## IMPORTANT: Complete Device Entries

For devices with many missing types (50+), it may be easier to output a **complete replacement** instead of amendments:

```json
{
  "deviceKey": "ThingStructureNitrolyzer",
  "replaceAll": true,
  "logicDescriptions": {
    "Power": { "dataType": "Boolean", "range": "0-1", "description": "..." },
    "On": { "dataType": "Boolean", "range": "0-1", "description": "..." },
    // ... ALL logic types
  }
}
```

## Devices to Prioritize

Focus on devices with these characteristics:
1. Has `Mode` logic type - ALWAYS verify
2. Has `Setting` that isn't obvious (not just On/Off)
3. Has `Ratio`, `Output`, `Input` types
4. Complex devices: Furnaces, Fabricators, IC Housings, Sensors

## What NOT to Change

These are usually correct and don't need verification:
- `Power` - Always 0/1 powered state
- `On` - Always 0/1 on/off state (unless device is special)
- `RequiredPower` - Always watts
- `Temperature` - Always Kelvin
- `Pressure` - Always kPa
- `ReferenceId` - Always unique ID
- `PrefabHash` - Always CRC32 hash

## Example Verification Workflow

### Device: ThingStructureBatteryLarge

1. **Find source**: `Assembly-CSharp/Assets/Scripts/Objects/Electrical/Battery.cs`

2. **Check Mode**:
```csharp
public override string[] ModeStrings => Battery.BatteryModeStrings;
public static string[] BatteryModeStrings = Enum.GetNames(typeof(BatteryCellState));
```

3. **Find enum**:
```csharp
public enum BatteryCellState { Empty, Critical, VeryLow=2, Low=3, Medium, High, Full }
```

4. **Check if writable**:
```csharp
public override bool CanLogicWrite(LogicType logicType)
{
    return logicType != LogicType.Mode && base.CanLogicWrite(logicType);  // MODE IS READ-ONLY!
}
```

5. **Write accurate description**:
```json
"Mode": {
  "dataType": "Integer", 
  "range": "0-6",
  "description": "Read-only charge state: 0=Empty, 1=Critical, 2=VeryLow, 3=Low, 4=Medium, 5=High, 6=Full."
}
```

## Completion Report

After reviewing your batch, report:
```
BATCH {N} REVIEW COMPLETE
-------------------------
Devices reviewed: {count}
Devices amended: {count}
Devices correct (no changes): {count}

Key fixes made:
- ThingStructureBatteryLarge: Mode was wrong (said Auto/Charging, actually charge state)
- ThingStructureActiveVent: Mode verified correct
- ...

Amendments saved to: coordination/outputs/batch-{N}-amendments.json
```

---

## Your Assignment

1. Load your original batch output
2. For each device with Mode/Setting/Ratio/etc., find the source file
3. Verify the description matches what the code actually does
4. Create amendments file with fixes
5. Report back with summary

**Work autonomously. Read the actual source code. No guessing.**
