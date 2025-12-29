# Changelog

All notable changes to Stationpedia Ascended will be documented in this file.

## [0.1.0-beta] - 2025-12-28

### 🎉 Initial Release (Beta)
- **Renamed** from StationpediaPlus to **Stationpedia Ascended**
- **Custom Phoenix Icon** - Replaced the original book icon with a custom phoenix logo in the header

### ✨ New Features
- **Enhanced Tooltips System**
  - Added comprehensive tooltips for logic descriptions
  - Added slot-specific tooltips with detailed information
  - Added memory/register tooltips explaining functionality
  - Added mode descriptions for device operations
  - Added connection type explanations
  - JSON-based configuration system for easy customization

- **Operational Details Section**
  - Added dedicated "Operational Details" category that appears at the top of device pages
  - Configurable title color via JSON configuration
  - Phoenix icon displayed next to the category title
  - Defaults to collapsed state for cleaner initial view
  - Automatically positioned after the main description section

- **Page Description Customization**
  - Added ability to completely replace page descriptions
  - Added `pageDescriptionAppend` for adding content after existing descriptions
  - Added `pageDescriptionPrepend` for adding content before existing descriptions
  - Full JSON configuration support via `descriptions.json`

### 🐛 Bug Fixes
- **Fixed Critical Scrollbar Handle Bug**
  - Resolved issue where scrollbar handles would disappear on non-home Stationpedia pages
  - Implemented 5-frame delayed fix to combat handle position corruption
  - Handle `localPosition` and `anchoredPosition` now properly reset to zero
  - Bug affects base game - created detailed bug report for developers

- **Fixed Window Dragging Crash**
  - Resolved crash when dragging Stationpedia window in main menu
  - Fixed `ClampToScreen()` null reference exception due to missing `InventoryManager.ParentHuman`
  - Replaced problematic dragging logic with simple position assignment

### 🔧 Technical Improvements
- **Harmony Integration**
  - Patches `ChangeDisplay` method for enhanced functionality
  - Patches `PopulateLogicSlotInserts` for tooltip integration
  - Patches `OnDrag` and `OnBeginDrag` for improved window handling
  - Hot-reload support for development workflow

- **Performance Optimizations**
  - Coroutine-based monitoring system for Stationpedia state
  - Efficient component cleanup on mod reload
  - Delayed tooltip application to prevent UI conflicts

- **Developer Experience**
  - ScriptEngine hot-reload compatibility (F6 reload support)
  - Comprehensive debug logging system
  - Automatic file path detection for development and production environments

### 📝 Documentation
- Created comprehensive bug report document for game developers
- Added detailed JSON configuration examples
- Documented all tooltip categories and customization options

### 🎨 UI/UX Improvements
- **Custom Branding**
  - Window title changed to "Stationpedia Ascended" with orange accent color
  - Phoenix icon properly sized and positioned in header
  - Maintains original UI layout and responsiveness

- **Enhanced Information Display**
  - Tooltips appear on hover with orange border styling
  - Consistent formatting across all tooltip categories
  - Non-intrusive design that complements existing UI

### ⚙️ Configuration
- **descriptions.json Structure**
  ```json
  {
    "genericDescriptions": {
      "logic": { "key": "description" },
      "slots": { "key": "description" },
      "memory": { "key": "description" },
      "modes": { "key": "description" },
      "connections": { "key": "description" }
    },
    "devices": {
      "DevicePageKey": {
        "operationalDetails": [...],
        "operationalDetailsTitleColor": "#FF7A18",
        "pageDescription": "Complete replacement",
        "pageDescriptionAppend": "Added after existing",
        "pageDescriptionPrepend": "Added before existing"
      }
    }
  }
  ```

### 🔄 Compatibility
- Compatible with Stationeers current version
- Works with both BepInEx and ScriptEngine loading methods
- Hot-reload support for development
- No conflicts with existing Stationpedia functionality

---

*Note: This is a beta release. Please report any issues or feedback on the GitHub repository.*