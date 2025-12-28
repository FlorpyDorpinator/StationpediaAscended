## Plan: StationpediaPlus Comprehensive Expansion

Expand StationpediaPlus to provide context-sensitive hover tooltips for ALL 694+ programmable devices across 7 category types: Logic, LogicSlot, Mode, Connection, Slots, StructureVersions, and Internal Memory (Instructions). Determine which descriptions should be generic vs device-specific, then use 8 parallel agents to document all devices systematically.

---

## Progress Tracker

| Phase | Status | Description |
|-------|--------|-------------|
| 1 | ✅ Complete | Expand Data Model & JSON Schema |
| 2 | ✅ Complete | Hook Remaining Stationpedia Categories |
| 3 | ✅ Complete | Test Working Prototype |
| 4 | ✅ Complete | Extract & Categorize All Device Keys |
| 5 | ⏭️ Skipped | Analyze Generic vs Device-Specific (merged into agent work) |
| 6 | ⏭️ Skipped | Create Generic Descriptions (merged into agent work) |
| 7 | ✅ Complete | Create Batch Assignment System |
| 8 | ✅ Complete | Document Agent Workflow Instructions |
| 9 | 🔄 In Progress | Execute Batch Processing (8 Agents) |
| 10 | ⬜ Not Started | Final Integration & Validation |

**Current Phase**: 9b - Review pass for device-specific logic types  
**Last Updated**: 2025-12-27

### Phase 9 Status

| Batch | Assigned | Completed | Skipped | Status |
|-------|----------|-----------|---------|--------|
| 1 | 61 | 9 | 52 | ❌ Agent stopped early |
| 2 | 61 | 62 | 0 | ✅ Complete (+ 1 extra) |
| 3 | 61 | 10 | 51 | ❌ Agent stopped early |
| 4 | 61 | 10 | 51 | ❌ Agent stopped early |
| 5 | 61 | 61 | 0 | ✅ Complete |
| 6 | 61 | 61 | 0 | ✅ Complete |
| 7 | 61 | 8 | 53 | ❌ Agent stopped early |
| 8 | 58 | 58 | 0 | ✅ Complete |
| **Total** | **485** | **279** | **207** | **58% done** |

### Phase 9b: Review Pass

**Problems Identified**:
1. **MISSING logic types**: 278 devices missing 3,789 total entries
2. **Hallucinated descriptions**: Device-specific types (Mode, Setting, etc.) not verified against source

**Logic types needing verification** (vary per device):
- `Mode`, `Setting`, `Ratio`, `Error`, `Lock`, `Activate`, `Output`, `Input`

**Review stats per batch**:
| Batch | Devices | Need Review | Missing Types |
|-------|---------|-------------|---------------|
| 1 | 9 | 8 | ~100+ |
| 2 | 62 | 50 | ~500+ |
| 3 | 10 | 10 | ~100+ |
| 4 | 10 | 8 | ~100+ |
| 5 | 61 | 44 | ~1000+ |
| 6 | 61 | 37 | ~800+ |
| 7 | 8 | 8 | ~100+ |
| 8 | 58 | 55 | ~1000+ |
| **Total** | **279** | **220** | **3,789** |

**Files created**:
- `coordination/agent-instructions/REVIEW-INSTRUCTIONS.md` - Agent review workflow
- `coordination/outputs/batch-{N}-review-list.json` - Per-batch devices needing fix verification
- `coordination/outputs/missing-logic-types.json` - All devices with missing types

**Next**: Re-run agents to:
1. Add ALL missing logic types
2. Verify Mode/Setting/etc against source code

---

## Phases

### Phase 1: Expand Data Model & JSON Schema
- **Objective:** Update the C# data classes and JSON format to support all 7 category types
- **Files/Functions to Modify/Create:**
  - `StationpediaPlus.cs` - Add new dictionary properties to `DeviceDescriptions` class
  - `descriptions.json` - Update schema with new category sections
- **Tests to Write:**
  - Test JSON loads with new schema without errors
  - Test each new dictionary can be accessed
- **Steps:**
  1. Add `slotDescriptions`, `versionDescriptions`, `memoryDescriptions` dictionaries to `DeviceDescriptions` class
  2. Update `GetLogicDescription()` to handle new category types or create separate methods
  3. Create example JSON entries demonstrating new schema
  4. Test JSON loading works correctly

---

### Phase 2: Hook Remaining Stationpedia Categories
- **Objective:** Attach tooltip components to Slots, Versions, and Memory/Instructions UI elements
- **Files/Functions to Modify/Create:**
  - `StationpediaPlus.cs` - Add methods: `AddTooltipsToSlots()`, `AddTooltipsToVersions()`, `AddTooltipsToMemory()`
- **Tests to Write:**
  - Test tooltips appear on SPDASlot elements
  - Test tooltips appear on SPDAVersion elements  
  - Test tooltips appear on SPDAGeneric (Memory) elements
- **Steps:**
  1. Create `AddTooltipsToSlots()` method targeting `SlotContents` category
  2. Create `AddTooltipsToVersions()` method targeting `StructureVersionContents` category
  3. Create `AddTooltipsToMemory()` method targeting `LogicInstructions` category
  4. Update `Update()` to call new methods on page change
  5. Create appropriate tooltip component classes if needed

---

### Phase 3: Test Working Prototype
- **Objective:** Verify all 7 category types display tooltips correctly before batching
- **Files/Functions to Modify/Create:**
  - `descriptions.json` - Add test entries for each category type
- **Tests to Write:**
  - Manual test: Logic tooltips (existing - verify still works)
  - Manual test: LogicSlot tooltips (existing - verify still works)
  - Manual test: Mode tooltips (existing - verify still works)
  - Manual test: Connection tooltips (existing - verify still works)
  - Manual test: Slot tooltips (NEW)
  - Manual test: Version tooltips (NEW)
  - Manual test: Memory/Instruction tooltips (NEW)
- **Steps:**
  1. Add test device with all 7 category types to JSON
  2. Build and deploy mod
  3. Open Stationpedia to test device page
  4. Verify each category type shows tooltip on hover
  5. Document any issues and fix before proceeding

---

### Phase 4: Extract & Categorize All Device Keys
- **Objective:** Build complete list of all 694+ device page keys and what categories each has
- **Files/Functions to Modify/Create:**
  - `plans/device-inventory.csv` - Master list of all devices
  - PowerShell extraction script
- **Tests to Write:**
  - Verify device count matches expected ~694
  - Verify categorization is correct for sample devices
- **Steps:**
  1. Extract all page keys from Stationpedia.json
  2. Cross-reference with decompiled code to determine categories per device
  3. Flag devices with Memory/Instructions (18 known)
  4. Output CSV: PageKey, DisplayName, HasLogic, HasLogicSlot, HasMode, HasConnection, HasSlots, HasVersions, HasMemory

---

### Phase 5: Analyze Generic vs Device-Specific Types
- **Objective:** Determine which Logic/Slot/Mode/etc types should have generic descriptions vs device-specific
- **Files/Functions to Modify/Create:**
  - `plans/generic-types-analysis.md` - Analysis document
- **Tests to Write:**
  - N/A (research phase)
- **Steps:**
  1. Extract all unique LogicType values used across devices
  2. Count how many devices use each LogicType
  3. Categorize as GENERIC (same meaning everywhere) or DEVICE-SPECIFIC (meaning varies)
  4. Examples of GENERIC: Power, RequiredPower, ReferenceId, On, Error, Lock
  5. Examples of DEVICE-SPECIFIC: Setting, Ratio, Output, Input (meaning depends on device)
  6. Repeat for LogicSlotType, Mode enums, Connection types
  7. Create final list of types that need generic descriptions

---

### Phase 6: Create Generic Descriptions
- **Objective:** Write generic descriptions for all universal types identified in Phase 5
- **Files/Functions to Modify/Create:**
  - `descriptions.json` - Populate `genericDescriptions` section
- **Tests to Write:**
  - Test generic descriptions load correctly
  - Test fallback to generic works when device-specific not found
- **Steps:**
  1. Write descriptions for all GENERIC LogicTypes (est. 20-40 types)
  2. Write descriptions for all GENERIC LogicSlotTypes
  3. Write descriptions for all GENERIC Mode values
  4. Write descriptions for all GENERIC Connection types
  5. Test fallback mechanism in mod

---

### Phase 7: Create Batch Assignment System
- **Objective:** Divide remaining device-specific work into 8 equal batches
- **Files/Functions to Modify/Create:**
  - `plans/batch-1.json` through `plans/batch-8.json` - Device assignments
  - `plans/batch-template.md` - Template for agent instructions
- **Tests to Write:**
  - Verify all 694 devices assigned to exactly one batch
  - Verify batches are roughly equal size
- **Steps:**
  1. Remove devices that only need generic descriptions (if any)
  2. Divide remaining devices into 8 batches (~87 devices each)
  3. For each batch, list: PageKey, DisplayName, Categories to document
  4. Create JSON template showing expected output format per device

---

### Phase 8: Document Agent Workflow Instructions
- **Objective:** Create comprehensive instructions for batch documentation agents
- **Files/Functions to Modify/Create:**
  - `plans/agent-instructions.md` - Complete agent workflow guide
- **Tests to Write:**
  - N/A (documentation)
- **Steps:**
  1. Document how to find device info in decompiled code
  2. Document JSON format for each category type
  3. Provide examples of good descriptions (brief, 1-3 sentences)
  4. List all 18 memory-enabled devices and their instruction types
  5. Document opcode lookup process for memory instructions
  6. Include common pitfalls and quality guidelines

---

### Phase 9: Execute Batch Processing (8 Agents)
- **Objective:** Run 8 parallel agents to document all devices
- **Files/Functions to Modify/Create:**
  - `descriptions-batch-1.json` through `descriptions-batch-8.json` - Agent outputs
- **Tests to Write:**
  - Validate each batch output against JSON schema
  - Verify all assigned devices are documented
- **Steps:**
  1. Launch Agent 1 with batch-1.json assignment
  2. Launch Agent 2 with batch-2.json assignment
  3. ... (repeat for all 8 agents)
  4. Collect and validate outputs
  5. Address any validation errors

---

### Phase 10: Final Integration & Validation
- **Objective:** Merge all batch outputs and verify complete coverage
- **Files/Functions to Modify/Create:**
  - `descriptions.json` - Final merged file
  - `README.md` - Mod documentation
- **Tests to Write:**
  - Test merged JSON loads without errors
  - Test sample devices from each batch
  - Test all 18 memory-enabled devices show instruction tooltips
- **Steps:**
  1. Merge 8 batch outputs into single descriptions.json
  2. Run validation to check all devices covered
  3. Test representative devices in-game
  4. Create user documentation
  5. Package final mod release

---

## Open Questions (Resolved)

| Question | Decision |
|----------|----------|
| Batch size strategy? | ✅ 8 equal batches |
| Description depth? | ✅ Brief, 1-3 sentences |
| Generic vs device-specific? | ✅ Phase 5 will analyze and determine |
| Memory instructions scope? | ✅ ALL opcodes for ALL 18 devices |
| Prototype first? | ✅ Yes, Phase 3 tests before batching |

---

## Notes

- **Memory-enabled devices (18)**: Fabricators (multiple), Logic Sorter, Satellite Dish, Occupancy Sensor, Rocket Avionics, Celestial Tracking components
- **Instruction types**: PrinterInstruction, SorterInstruction, TraderInstruction, OccupancyInstruction, RocketAvionicsInstruction, CelestialTracking
