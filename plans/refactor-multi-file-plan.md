## Plan: Refactor StationpediaAscended into Multi-File Structure

Break up the 2,535-line monolithic `StationpediaAscended.cs` into ~12 focused files organized by responsibility, eliminate code duplication in tooltip components using a base class, and unify the dual init paths (BepInEx vs ScriptEngine) through a shared core.

**Phases (5 phases)**

1. **Phase 1: Extract Data Models**
    - **Objective:** Move all JSON data model classes into a dedicated file
    - **Files/Functions to Modify/Create:** `mod/src/Data/Models.cs`
    - **Tests to Write:** Build verification only (no unit tests for DTOs)
    - **Steps:**
        1. Create `mod/src/Data/` directory structure
        2. Move 8 data model classes to `Models.cs`
        3. Update .csproj with wildcard include for `src\**\*.cs`
        4. Build and verify no compilation errors

2. **Phase 2: Create Base Tooltip and Extract Tooltip Components**
    - **Objective:** Eliminate 80% code duplication across 4 tooltip classes
    - **Files/Functions to Modify/Create:** 
      - `mod/src/Tooltips/SPDABaseTooltip.cs`
      - `mod/src/Tooltips/SPDALogicTooltip.cs`
      - `mod/src/Tooltips/SPDASlotTooltip.cs`
      - `mod/src/Tooltips/SPDAVersionTooltip.cs`
      - `mod/src/Tooltips/SPDAMemoryTooltip.cs`
    - **Tests to Write:** In-game tooltip hover test
    - **Steps:**
        1. Create abstract `SPDABaseTooltip` with shared hover delay, pointer events, tooltip display
        2. Each concrete tooltip only overrides `FormatTooltip()` and lookup methods
        3. Move each class to its own file
        4. Remove old classes from main file
        5. Build and verify

3. **Phase 3: Extract Harmony Patches**
    - **Objective:** Move all Harmony patch code into a dedicated file
    - **Files/Functions to Modify/Create:** `mod/src/Harmony/Patches.cs`
    - **Tests to Write:** In-game page change test
    - **Steps:**
        1. Move `StationpediaPatches` static class with all patch methods
        2. Move helper methods (`CondenseSlotNumbers`, `ValidateSlotsString`, etc.)
        3. Move `FixScrollbarHandleCoroutine`
        4. Update references to use `TooltipState` for shared state
        5. Build and verify patches still apply

4. **Phase 4: Extract Core Services**
    - **Objective:** Create focused service classes for loading, state, and monitoring
    - **Files/Functions to Modify/Create:**
      - `mod/src/Core/TooltipState.cs`
      - `mod/src/Core/DescriptionLoader.cs`
      - `mod/src/Core/PathResolver.cs`
      - `mod/src/Core/IconLoader.cs`
      - `mod/src/Core/StationpediaMonitor.cs`
    - **Tests to Write:** JSON loading test, in-game monitor test
    - **Steps:**
        1. Create `TooltipState` with `CurrentTooltipText`, `ShowTooltip`
        2. Create `DescriptionLoader` with JSON loading logic
        3. Create `PathResolver` with path probing candidates
        4. Create `IconLoader` with icon loading
        5. Create `StationpediaMonitor` with coroutine and tooltip attachment
        6. Build and verify

5. **Phase 5: Unify Init Paths and Slim Plugin**
    - **Objective:** Create unified core for both BepInEx and ScriptEngine paths
    - **Files/Functions to Modify/Create:**
      - `mod/src/Plugin/StationpediaAscendedPlugin.cs`
      - `mod/src/Plugin/ScriptEngineEntry.cs`
      - `mod/src/Core/ModCore.cs`
    - **Tests to Write:** Cold start test, hot-reload (F6) test
    - **Steps:**
        1. Create `ModCore` with `Initialize()` and `Cleanup()`
        2. Slim down plugin to thin facade calling ModCore
        3. Update ScriptEngine entry to call ModCore
        4. Delete original `StationpediaAscended.cs`
        5. Full build and test both paths

**Open Questions**
1. None - user approved all decisions.
