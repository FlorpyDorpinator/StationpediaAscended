## Plan: StationpediaPlus Phase 1 - Context-Specific Logic Tooltips

Create a BepInEx mod that adds context-specific hover tooltips to Stationpedia Logic sections, displaying information in table format (Data Type | Range/Units | Description) for three test devices.

**Phases: 4 phases**

1. **Phase 1: Mod Project Structure**
    - **Objective:** Create the mod folder structure compatible with StationeersLaunchPad
    - **Files/Functions to Modify/Create:** 
      - `StationpediaPlus/About.xml` - mod metadata
      - `StationpediaPlus/StationpediaPlus.cs` - main plugin with Harmony patches
      - `StationpediaPlus/descriptions.json` - external context data file
    - **Tests to Write:** Manual verification mod loads in LaunchPad config screen
    - **Steps:**
        1. Create mod folder in workspace
        2. Create About.xml with mod metadata
        3. Create basic plugin class with `[StationeersMod]` attribute
        4. Verify structure matches LaunchPad requirements

2. **Phase 2: Tooltip Component & Harmony Patch**
    - **Objective:** Create tooltip component that displays on hover over SPDALogic items
    - **Files/Functions to Modify/Create:**
      - `SPDALogicTooltip.cs` - custom tooltip component extending game's ToolTipBase
      - Harmony Postfix patch for `UniversalPage.PopulateLogicInserts()`
    - **Tests to Write:** Manual test - hover over any logic type shows tooltip
    - **Steps:**
        1. Create SPDALogicTooltip class inheriting from ToolTipBase
        2. Implement GetString() to return formatted tooltip text
        3. Create Harmony patch to inject tooltip component after SPDALogic instantiation
        4. Add description lookup from JSON database

3. **Phase 3: Document Three Test Devices**
    - **Objective:** Create comprehensive context descriptions for Aimee, Advanced Furnace, and Satellite Dish
    - **Files/Functions to Modify/Create:**
      - `descriptions.json` - populated with device-specific logic descriptions
    - **Tests to Write:** Manual test - verify each device shows correct context tooltips
    - **Steps:**
        1. Analyze Aimee (RobotMining) code for Mode, TargetX/Y/Z, MineablesInVicinity context
        2. Analyze Advanced Furnace code for Mode, SettingInput, SettingOutput context
        3. Analyze SatelliteDish code for SignalStrength, WattsReachingContact, etc. context
        4. Write descriptions in aimee.md table format

4. **Phase 4: Build & In-Game Testing**
    - **Objective:** Compile mod, deploy to Stationeers mods folder, test in-game
    - **Files/Functions to Modify/Create:**
      - Compiled DLL
      - Deployment script/instructions
    - **Tests to Write:** Full in-game verification of all three devices
    - **Steps:**
        1. Build mod DLL
        2. Copy to `Documents/My Games/Stationeers/mods/StationpediaPlus/`
        3. Launch game with StationeersLaunchPad
        4. Open Stationpedia, navigate to test devices, verify tooltips

**Open Questions**
1. Should we use Unity's built-in tooltip system or create custom UI panel? Using existing ToolTipBase for consistency
2. How to handle logic types that don't have context descriptions? Fall back to generic Enums.json description
3. Should tooltip include IC10 example snippets? Not in Phase 1, consider for Phase 2
