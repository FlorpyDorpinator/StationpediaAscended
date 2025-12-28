# {Device Display Name}

> **Class**: `{ClassName}` | **Source**: `{SourceFile}` | **Category**: {Category}

## Overview

{1-2 sentence description of what this device does and its primary purpose in the game.}

## Logic Types

### Readable (l instruction)

| LogicType | Data Type | Range/Values | Description |
|-----------|-----------|--------------|-------------|
| `Power` | Boolean | 0/1 | Whether the device is powered |
| `On` | Boolean | 0/1 | Whether the device is enabled |
| `RequiredPower` | Float | Watts | Power required to operate |
| `{LogicType}` | {Type} | {Range} | {Description} |

### Writable (s instruction)

| LogicType | Data Type | Range/Values | Description |
|-----------|-----------|--------------|-------------|
| `On` | Boolean | 0/1 | Enable/disable the device |
| `{LogicType}` | {Type} | {Range} | {Description} |

### Read-Only (Cannot Write)

- `Power` - Actual power state depends on electrical network
- `{LogicType}` - {Reason}

### Write-Only (Cannot Read)

- `{LogicType}` - {Description and why it's write-only}

### Slot Logic (ls/ss instructions)

| Slot | LogicType | R/W | Description |
|------|-----------|-----|-------------|
| 0 | `Occupied` | R | Whether slot contains an item |
| 0 | `OccupantHash` | R | PrefabHash of item in slot |
| 0 | `Quantity` | R | Stack size in slot |
| {N} | `{LogicType}` | {R/W} | {Description} |

## Reagent Logic (lr instruction)

| Reagent | Description |
|---------|-------------|
| Contents | {What the contents represent} |

## Special Behaviors

### Mode Values
{If the device has a Mode property, document what each mode value means.}

| Mode | Meaning |
|------|---------|
| 0 | {Description} |
| 1 | {Description} |

### State Transitions
{Document any automatic state changes or triggered behaviors.}

### Important Notes
- {Note about behavior that isn't obvious from the logic types}
- {Gotcha or common mistake}
- {Interaction with other devices}

## IC10 Examples

### Basic Control
```
alias Device d0
s Device On 1      # Turn on
l r0 Device Power  # Read power state
```

### {Specific Use Case}
```
# {Comment explaining what this does}
{IC10 code}
```

## Inheritance

**Parent Class**: `{ParentClass}`  
**Inherits Logic From**: {List of base classes whose logic this inherits}

{Note: Document only logic types that this specific class adds or modifies. See {ParentClass} documentation for inherited types.}

## Related Devices

- [{Related Device 1}](related-device-1.md) - {Relationship}
- [{Related Device 2}](related-device-2.md) - {Relationship}

---
*Generated from source analysis. Last updated: {Date}*  
*Review Status: {draft/pending/reviewed/approved}*
