# add-remaining-descriptions.ps1
# Adds Connection, Slot Type, and Memory Instruction descriptions to descriptions.json

$modDir = "C:\Dev\12-17-25 Stationeers Respawn Update Code\StationpediaPlus\mod"
$descFile = Join-Path $modDir "descriptions.json"

# Load existing descriptions
$desc = Get-Content $descFile -Raw | ConvertFrom-Json

# ============================================================================
# CONNECTION DESCRIPTIONS
# ============================================================================
$connectionDescriptions = @{
    "Connection" = @{
        "type" = "Data"
        "description" = "Generic data connection for logic communication between devices."
    }
    "Data Input" = @{
        "type" = "Data"
        "description" = "Receives data signals from connected logic devices."
    }
    "Data Output" = @{
        "type" = "Data"
        "description" = "Sends data signals to connected logic devices."
    }
    "Power Input" = @{
        "type" = "Power"
        "description" = "Receives electrical power from the power network."
    }
    "Power Output" = @{
        "type" = "Power"
        "description" = "Outputs electrical power to the power network."
    }
    "Power and Data Input" = @{
        "type" = "Power/Data"
        "description" = "Combined connection that receives both power and data signals."
    }
    "Power and Data Output" = @{
        "type" = "Power/Data"
        "description" = "Combined connection that outputs both power and data signals."
    }
    "Pipe Input" = @{
        "type" = "Gas"
        "description" = "Receives gases from the pipe network."
    }
    "Pipe Output" = @{
        "type" = "Gas"
        "description" = "Outputs gases to the pipe network."
    }
    "Pipe Input 2" = @{
        "type" = "Gas"
        "description" = "Secondary gas input connection."
    }
    "Pipe Output 2" = @{
        "type" = "Gas"
        "description" = "Secondary gas output connection."
    }
    "Pipe Waste" = @{
        "type" = "Gas"
        "description" = "Outputs waste gases or byproducts to the pipe network."
    }
    "Pipe Liquid Input" = @{
        "type" = "Liquid"
        "description" = "Receives liquids from the liquid pipe network."
    }
    "Pipe Liquid Output" = @{
        "type" = "Liquid"
        "description" = "Outputs liquids to the liquid pipe network."
    }
    "Pipe Liquid Input 2" = @{
        "type" = "Liquid"
        "description" = "Secondary liquid input connection."
    }
    "Pipe Liquid Output 2" = @{
        "type" = "Liquid"
        "description" = "Secondary liquid output connection."
    }
    "Pipe Liquid Waste" = @{
        "type" = "Liquid"
        "description" = "Outputs waste liquids to the liquid pipe network."
    }
    "Chute Input" = @{
        "type" = "Chute"
        "description" = "Receives items from connected chute network."
    }
    "Chute Output" = @{
        "type" = "Chute"
        "description" = "Outputs items to connected chute network."
    }
    "Chute Input 2" = @{
        "type" = "Chute"
        "description" = "Secondary chute input connection."
    }
    "Chute Output 2" = @{
        "type" = "Chute"
        "description" = "Secondary chute output connection."
    }
    "Landing Pad Input" = @{
        "type" = "Landing"
        "description" = "Connection point for rocket landing pad systems."
    }
    " Input" = @{
        "type" = "Unknown"
        "description" = "Input connection."
    }
}

# ============================================================================
# SLOT TYPE DESCRIPTIONS
# ============================================================================
$slotTypeDescriptions = @{
    "Entity" = "Accepts entities (players, NPCs, creatures)."
    "Seat" = "Seating position for players."
    "Battery" = "Accepts battery cells for power storage."
    "Programmable Chip" = "Accepts IC10 programmable chips."
    "Ore" = "Accepts raw ore for processing."
    "Access Card" = "Accepts access cards for authentication."
    "Data Disk" = "Accepts data disks for storage/transfer."
    "Import" = "Input slot for items to be processed."
    "Export" = "Output slot for processed items."
    "Export 2" = "Secondary output slot for processed items."
    "Cartridge" = "Accepts atmospheric filter cartridges."
    "Cartridge1" = "Primary cartridge slot."
    "Plant" = "Accepts plants or seeds for growing."
    "Appliance 1" = "Primary appliance slot."
    "Appliance 2" = "Secondary appliance slot."
    "Bed" = "Sleeping position slot."
    "Brain" = "Accepts brain items (medical/NPC)."
    "Lungs" = "Accepts lung items (medical/NPC)."
    "Burger" = "Accepts food items for serving."
    "None" = "General purpose slot with no type restriction."
    "Storage" = "General storage slot for items."
    "Output" = "Output slot for produced items."
    "Input" = "Input slot for items to process."
    "Transport Slot" = "Slot for items being transported."
    "Motherboard" = "Accepts motherboard circuit boards."
    "Circuitboard" = "Accepts specialized circuit boards."
    "Container Slot" = "Accepts portable containers."
    "Player" = "Slot that accepts player entities."
    "Mask" = "Accepts face mask equipment."
    "Egg" = "Accepts eggs for incubation."
    "Air Tank" = "Accepts portable air tanks."
    "Waste Tank" = "Accepts waste collection tanks."
    "Life Support" = "Accepts life support equipment."
    "Filter" = "Accepts filter items."
    "Filter1" = "Primary filter slot."
    "Filter2" = "Secondary filter slot."
    "Filter3" = "Tertiary filter slot."
    "Filter4" = "Quaternary filter slot."
    "Tool" = "Accepts tools and equipment."
    "Gas Filter" = "Accepts gas filtration cartridges."
    "Fire Extinguisher" = "Accepts fire extinguisher equipment."
    "Magazine" = "Accepts ammunition magazines."
    "Chamber" = "Weapon chamber slot."
    "Gas Mask" = "Accepts gas mask equipment."
    "Gas Canister" = "Accepts portable gas canisters."
    "Coolant Tank" = "Accepts coolant storage tanks."
    "Chip" = "Accepts microchip items."
    "Back" = "Back-mounted equipment slot."
    "Propellant" = "Accepts propellant for jetpacks/rockets."
    "Hand" = "Hand-held item slot."
    "Fertiliser" = "Accepts fertilizer for plants."
    "Portable slot" = "Accepts portable equipment."
    "Credit Card" = "Accepts credit cards for transactions."
    "Arm Slot" = "Robotic arm attachment slot."
    "Proxy" = "Proxy connection slot."
    "Hopper Slot" = "Accepts items for hopper input."
    "Crate Slot" = "Accepts crates for storage."
    "Liquid Canister" = "Accepts liquid storage canisters."
    "Payload" = "Accepts payload items for delivery."
    "Recipient" = "Accepts items as recipient."
    "SoundCartridge" = "Accepts sound/music cartridges."
    "Source Plant" = "Source plant for genetic operations."
    "Target Plant" = "Target plant for genetic operations."
    "Drill Head Slot" = "Accepts mining drill heads."
    "Scanner Head Slot" = "Accepts scanner head attachments."
    "Sensor Processing Unit" = "Accepts sensor processing units."
    "Spray Can" = "Accepts spray paint cans."
    "Processing" = "Slot for items being processed."
    "Helmet" = "Accepts helmet equipment."
    "Suit" = "Accepts suit equipment."
    "Tablet" = "Accepts tablet devices."
    "Dirt Canister" = "Accepts dirt/soil canisters."
    "Bottle Slot" = "Accepts bottle items."
    "<N:EN:>" = "Unnamed slot type."
    "<N:EN:Liquid Canister>" = "Liquid canister slot."
    "<N:EN:ContainerConnection>" = "Container connection slot."
    "<N:EN:GasTankConnection>" = "Gas tank connection slot."
}

# ============================================================================
# MEMORY INSTRUCTION DESCRIPTIONS
# ============================================================================
$memoryDescriptions = @{
    # SorterInstruction (Logic Sorter)
    "SorterInstruction.None" = @{
        "opCode" = 0
        "parameters" = "none"
        "description" = "No operation. Placeholder instruction."
    }
    "SorterInstruction.FilterPrefabHashEquals" = @{
        "opCode" = 1
        "parameters" = "PrefabHash (int)"
        "description" = "Filter items where PrefabHash equals the specified value. Only matching items pass through."
    }
    "SorterInstruction.FilterPrefabHashNotEquals" = @{
        "opCode" = 2
        "parameters" = "PrefabHash (int)"
        "description" = "Filter items where PrefabHash does NOT equal the specified value. Non-matching items pass through."
    }
    "SorterInstruction.FilterSortingClassCompare" = @{
        "opCode" = 3
        "parameters" = "SortingClass (int), CompareType"
        "description" = "Filter items by comparing their SortingClass using the specified comparison operation."
    }
    "SorterInstruction.FilterSlotTypeCompare" = @{
        "opCode" = 4
        "parameters" = "SlotType (int), CompareType"
        "description" = "Filter items by comparing their SlotType using the specified comparison operation."
    }
    "SorterInstruction.FilterQuantityCompare" = @{
        "opCode" = 5
        "parameters" = "Quantity (int), CompareType"
        "description" = "Filter items by comparing their stack quantity using the specified comparison operation."
    }
    "SorterInstruction.LimitNextExecutionByCount" = @{
        "opCode" = 6
        "parameters" = "Count (int)"
        "description" = "Limits the next filter instruction to only process the specified number of items."
    }
    
    # TraderInstruction (Satellite Dish)
    "TraderInstruction.None" = @{
        "opCode" = 0
        "parameters" = "none"
        "description" = "No operation. Placeholder instruction."
    }
    "TraderInstruction.WriteTraderData" = @{
        "opCode" = 1
        "parameters" = "Address, Value"
        "description" = "Writes data to the trader communication buffer."
    }
    "TraderInstruction.StrongestContactIdHash" = @{
        "opCode" = 2
        "parameters" = "none"
        "description" = "Returns the ID hash of the strongest trader contact signal."
    }
    "TraderInstruction.StrongestContactMetaData" = @{
        "opCode" = 3
        "parameters" = "none"
        "description" = "Returns metadata about the strongest trader contact."
    }
    "TraderInstruction.StrongestContactSignalData" = @{
        "opCode" = 4
        "parameters" = "none"
        "description" = "Returns signal strength data for the strongest trader contact."
    }
    "TraderInstruction.WriteTraderBuyData" = @{
        "opCode" = 5
        "parameters" = "ItemHash, Quantity, Price"
        "description" = "Writes a buy order to purchase items from the trader."
    }
    "TraderInstruction.WriteTraderSellData" = @{
        "opCode" = 6
        "parameters" = "ItemHash, Quantity, Price"
        "description" = "Writes a sell order to sell items to the trader."
    }
    "TraderInstruction.TraderBuyThingData" = @{
        "opCode" = 7
        "parameters" = "PrefabHash"
        "description" = "Specifies an item to buy from the trader by PrefabHash."
    }
    "TraderInstruction.TraderBuyThingChildData" = @{
        "opCode" = 8
        "parameters" = "ParentHash, ChildHash"
        "description" = "Specifies a child item to buy (item contained within another item)."
    }
    "TraderInstruction.TraderBuyGasData" = @{
        "opCode" = 9
        "parameters" = "GasType, Amount"
        "description" = "Specifies gas to purchase from the trader."
    }
    "TraderInstruction.TraderSellThingData" = @{
        "opCode" = 10
        "parameters" = "PrefabHash"
        "description" = "Specifies an item to sell to the trader by PrefabHash."
    }
    "TraderInstruction.TraderSellGasData" = @{
        "opCode" = 11
        "parameters" = "GasType, Amount"
        "description" = "Specifies gas to sell to the trader."
    }
    "TraderInstruction.TraderSellThingChildData" = @{
        "opCode" = 12
        "parameters" = "ParentHash, ChildHash"
        "description" = "Specifies a child item to sell (item contained within another item)."
    }
    "TraderInstruction.FilterPrefabHashEquals" = @{
        "opCode" = 13
        "parameters" = "PrefabHash (int)"
        "description" = "Filter trade items where PrefabHash equals the specified value."
    }
    "TraderInstruction.FilterPrefabHashNotEquals" = @{
        "opCode" = 14
        "parameters" = "PrefabHash (int)"
        "description" = "Filter trade items where PrefabHash does NOT equal the specified value."
    }
    "TraderInstruction.FilterSortingClassCompare" = @{
        "opCode" = 15
        "parameters" = "SortingClass (int), CompareType"
        "description" = "Filter trade items by comparing their SortingClass."
    }
    "TraderInstruction.FilterQuantityCompare" = @{
        "opCode" = 16
        "parameters" = "Quantity (int), CompareType"
        "description" = "Filter trade items by comparing their quantity."
    }
    "TraderInstruction.FilterGasContains" = @{
        "opCode" = 17
        "parameters" = "GasType (int)"
        "description" = "Filter for items/containers that contain the specified gas type."
    }
    "TraderInstruction.FilterGasNotContains" = @{
        "opCode" = 18
        "parameters" = "GasType (int)"
        "description" = "Filter for items/containers that do NOT contain the specified gas type."
    }
    
    # PrinterInstruction (Electronics Printer, etc.)
    "PrinterInstruction.None" = @{
        "opCode" = 0
        "parameters" = "none"
        "description" = "No operation. Placeholder instruction."
    }
    "PrinterInstruction.StackPointer" = @{
        "opCode" = 1
        "parameters" = "Address"
        "description" = "Sets the instruction stack pointer to the specified address."
    }
    "PrinterInstruction.ExecuteRecipe" = @{
        "opCode" = 2
        "parameters" = "RecipeHash"
        "description" = "Executes the specified recipe if materials are available."
    }
    "PrinterInstruction.WaitUntilNextValid" = @{
        "opCode" = 3
        "parameters" = "none"
        "description" = "Pauses execution until the next instruction becomes valid."
    }
    "PrinterInstruction.JumpIfNextInvalid" = @{
        "opCode" = 4
        "parameters" = "Address"
        "description" = "Jumps to the specified address if the next recipe is invalid."
    }
    "PrinterInstruction.JumpToAddress" = @{
        "opCode" = 5
        "parameters" = "Address"
        "description" = "Unconditionally jumps to the specified instruction address."
    }
    "PrinterInstruction.DeviceSetLock" = @{
        "opCode" = 6
        "parameters" = "LockState (0/1)"
        "description" = "Sets the device lock state (0=unlocked, 1=locked)."
    }
    "PrinterInstruction.EjectReagent" = @{
        "opCode" = 7
        "parameters" = "ReagentHash"
        "description" = "Ejects the specified reagent from the printer."
    }
    "PrinterInstruction.EjectAllReagents" = @{
        "opCode" = 8
        "parameters" = "none"
        "description" = "Ejects all reagents from the printer."
    }
    "PrinterInstruction.MissingRecipeReagent" = @{
        "opCode" = 9
        "parameters" = "RecipeHash"
        "description" = "Returns the hash of a missing reagent needed for the recipe."
    }
    
    # OccupancyInstruction (Occupancy Sensor)
    "OccupancyInstruction.None" = @{
        "opCode" = 0
        "parameters" = "none"
        "description" = "No operation. Placeholder instruction."
    }
    "OccupancyInstruction.Entity" = @{
        "opCode" = 1
        "parameters" = "none"
        "description" = "Detects entity occupancy (players, NPCs, creatures)."
    }
    "OccupancyInstruction.Inventory" = @{
        "opCode" = 2
        "parameters" = "none"
        "description" = "Detects inventory occupancy (items in slots)."
    }
    
    # RocketAvionicsInstruction (Rocket Avionics)
    "RocketAvionicsInstruction.None" = @{
        "opCode" = 0
        "parameters" = "none"
        "description" = "No operation. Placeholder instruction."
    }
    "RocketAvionicsInstruction.StackPointer" = @{
        "opCode" = 1
        "parameters" = "Address"
        "description" = "Sets the avionics instruction stack pointer."
    }
    "RocketAvionicsInstruction.JumpToAddress" = @{
        "opCode" = 4
        "parameters" = "Address"
        "description" = "Jumps to the specified instruction address."
    }
    "RocketAvionicsInstruction.ChildResourceSite" = @{
        "opCode" = 5
        "parameters" = "ResourceType"
        "description" = "Targets a child resource site of the specified type for mining operations."
    }
    "RocketAvionicsInstruction.ChildSurveySite" = @{
        "opCode" = 6
        "parameters" = "SurveyType"
        "description" = "Targets a child survey site for scanning/surveying operations."
    }
}

# ============================================================================
# ADD TO DESCRIPTIONS
# ============================================================================

# Add connections section if not exists
if (-not $desc.genericDescriptions.connections) {
    $desc.genericDescriptions | Add-Member -NotePropertyName "connections" -NotePropertyValue @{} -Force
}
foreach ($key in $connectionDescriptions.Keys) {
    $desc.genericDescriptions.connections[$key] = $connectionDescriptions[$key]
}
Write-Host "Added $($connectionDescriptions.Count) connection descriptions"

# Add slot types section if not exists
if (-not $desc.genericDescriptions.slotTypes) {
    $desc.genericDescriptions | Add-Member -NotePropertyName "slotTypes" -NotePropertyValue @{} -Force
}
foreach ($key in $slotTypeDescriptions.Keys) {
    $desc.genericDescriptions.slotTypes[$key] = $slotTypeDescriptions[$key]
}
Write-Host "Added $($slotTypeDescriptions.Count) slot type descriptions"

# Add memory instructions section if not exists
if (-not $desc.genericDescriptions.memoryInstructions) {
    $desc.genericDescriptions | Add-Member -NotePropertyName "memoryInstructions" -NotePropertyValue @{} -Force
}
foreach ($key in $memoryDescriptions.Keys) {
    $desc.genericDescriptions.memoryInstructions[$key] = $memoryDescriptions[$key]
}
Write-Host "Added $($memoryDescriptions.Count) memory instruction descriptions"

# Save
$desc | ConvertTo-Json -Depth 15 | Out-File $descFile -Encoding UTF8
Write-Host "`nSaved to $descFile"
Write-Host "File size: $([math]::Round((Get-Item $descFile).Length / 1KB, 1)) KB"
