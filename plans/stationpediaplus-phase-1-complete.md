## Phase 1 Complete: Expand Data Model & JSON Schema

Expanded the C# data classes and JSON schema to support all 7 category types for tooltips: Logic, LogicSlot, Mode, Connection, Slots, Versions, and Memory/Instructions.

**Files created/changed:**
- StationpediaPlus/mod/StationpediaPlus.cs
- StationpediaPlus/mod/descriptions.json

**Functions created/changed:**
- `GetSlotDescription()` - New helper for slot tooltips with generic fallback
- `GetVersionDescription()` - New helper for version tooltips with generic fallback
- `GetMemoryDescription()` - New helper for memory instruction tooltips with generic fallback
- `LoadDescriptions()` - Updated to load new GenericDescriptionsData structure

**Classes created/changed:**
- `SlotDescription` - New class for slot type descriptions
- `VersionDescription` - New class for structure version descriptions
- `MemoryDescription` - New class for memory instruction/opcode descriptions
- `GenericDescriptionsData` - New class with sub-dictionaries (logic, slots, versions, memory)
- `DeviceDescriptions` - Added slotDescriptions, versionDescriptions, memoryDescriptions dictionaries
- `DescriptionsRoot` - Changed genericDescriptions from Dictionary to GenericDescriptionsData

**Tests created/changed:**
- None (manual verification of JSON loading)

**Review Status:** APPROVED

**Git Commit Message:**
```
feat: Expand data model for all Stationpedia tooltip categories

- Add SlotDescription, VersionDescription, MemoryDescription classes
- Add GenericDescriptionsData with logic/slots/versions/memory sub-dicts
- Add helper methods: GetSlotDescription, GetVersionDescription, GetMemoryDescription
- Update JSON schema to v2.0.0 with new category structure
- Add example entries for slots, versions, and memory instructions
```
