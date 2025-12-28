## Plan: Document Missing-Batch-4 Logic Descriptions

Document complete logic descriptions for 29 devices in missing-batch-4.json by extracting logic types from Stationpedia.json and verifying custom logic implementations in Assembly-CSharp source code, following strict TDD principles with validation at each step.

**Phases (5 phases)**

1. **Phase 1: Automated Initial Pass with Script**
    - **Objective:** Create and execute PowerShell script to extract all logic types from Stationpedia.json for the 29 batch-4 devices, auto-populate standard logic descriptions, and identify custom logic requiring source review
    - **Files/Functions to Modify/Create:**
        - Create process-batch-4.ps1
        - Read missing-batch-4.json
        - Read Stationpedia.json
        - Create missing-batch-4-complete.json
    - **Tests to Write:**
        - Test that script successfully loads missing-batch-4.json and extracts device keys
        - Test that script reads Stationpedia.json and finds pages for all devices
        - Test that standard logic types are populated with correct descriptions
        - Test that custom logic types are identified and marked for review
        - Test that output JSON structure matches specification format
    - **Steps:**
        1. Write test suite that verifies script can load batch file and extract device keys
        2. Run tests (should fail - script doesn't exist)
        3. Create process-batch-4.ps1 based on Agent 2's process-batch-2.ps1 pattern
        4. Write test that verifies Stationpedia.json parsing and logic extraction
        5. Add standard logic dictionary with 30+ predefined types
        6. Write test that validates output JSON format
        7. Execute script to generate initial output file
        8. Run all tests to confirm they pass

2. **Phase 2: Console Devices Source Code Review**
    - **Objective:** Review source code for console devices to document Mode, Setting, and any custom logic types specific to consoles (all variants share same logic)
    - **Files/Functions to Modify/Create:**
        - Read Console.cs, ConsoleBase.cs
        - Update missing-batch-4-complete.json for console entries
    - **Tests to Write:**
        - Test that Console.cs CanLogicRead method is parsed correctly
        - Test that extracted logic descriptions match source code implementation
        - Test that all console devices in batch have complete logic descriptions
    - **Steps:**
        1. Write test to verify Console.cs exists and contains CanLogicRead/GetLogicValue
        2. Run test (should fail - haven't read file yet)
        3. Search for Console*.cs files in Assembly-CSharp
        4. Read Console base class to understand logic implementation
        5. Write test that validates logic descriptions against source
        6. Extract Mode, Setting, and other custom logic meanings from source
        7. Update missing-batch-4-complete.json with verified console logic descriptions
        8. Run tests to confirm all console devices documented correctly

3. **Phase 3: Specialized Devices Source Code Review (Elevator, CryoTube, Furnace)**
    - **Objective:** Review source code for elevator components, cryo tubes, and furnace to document their specialized logic types (elevator shafts documented standalone without relationships)
    - **Files/Functions to Modify/Create:**
        - Read elevator-related source files in Assembly-CSharp
        - Read CryoTube.cs or similar
        - Read Furnace.cs or FurnaceBase.cs
        - Update missing-batch-4-complete.json
    - **Tests to Write:**
        - Test that elevator logic types are correctly extracted from source
        - Test that cryo tube logic types are correctly documented
        - Test that furnace logic types are correctly documented
    - **Steps:**
        1. Write tests to verify source files exist for each device type
        2. Run tests (should fail - haven't located files)
        3. Search for Elevator*, CryoTube*, and Furnace* source files
        4. Read each source file to understand custom logic implementations
        5. Write tests that validate extracted logic against source code
        6. Document Mode, Setting, Ratio, Error, and other custom types
        7. Update JSON file with verified descriptions
        8. Run tests to confirm specialized devices documented correctly

4. **Phase 4: Simple Devices (Fuses, Misc)**
    - **Objective:** Document logic for remaining devices including fuses, heat exchanger, locker, fountain, and gas tank (emergency items excluded per user direction)
    - **Files/Functions to Modify/Create:**
        - Search for Fuse, HeatExchanger, Locker, Fountain, Capsule source files
        - Update missing-batch-4-complete.json
    - **Tests to Write:**
        - Test that all non-emergency devices have complete logic descriptions
        - Test that simple devices with minimal logic are properly documented
        - Test that dataType and range fields are accurate for all logic types
    - **Steps:**
        1. Write test to verify no "TODO" strings remain in output JSON
        2. Run test (should fail - still have TODOs from Phase 1)
        3. Search for source files for remaining device types
        4. Read each source file to extract logic implementations
        5. Write tests validating completeness for each device category
        6. Document all remaining custom logic types
        7. Update JSON with final descriptions
        8. Run all tests to confirm completion

5. **Phase 5: Final Validation and Documentation**
    - **Objective:** Validate complete output file, run final format checks, ensure all devices have accurate logic descriptions from source code
    - **Files/Functions to Modify/Create:**
        - Validate missing-batch-4-complete.json
        - Create summary document listing all custom logic types discovered
    - **Tests to Write:**
        - Test that JSON is valid and parseable
        - Test that all expected devices are present in output
        - Test that every logic type has dataType, range, and description
        - Test that no placeholder or TODO text remains
        - Test that output file size is reasonable
    - **Steps:**
        1. Write comprehensive validation test suite
        2. Run tests (should pass if previous phases complete)
        3. Parse output JSON to verify structure
        4. Count devices, logic types, verify completeness
        5. Check for any remaining TODOs or placeholder text
        6. Validate dataType values are Boolean/Integer/Float only
        7. Generate summary report of all custom logic types found
        8. Run final test suite to confirm delivery-ready output

**User Clarifications:**
- Emergency items (ThingItemEmergency*) excluded from documentation
- Console variants all share identical logic implementations
- Elevator shafts documented standalone without relationship notes
