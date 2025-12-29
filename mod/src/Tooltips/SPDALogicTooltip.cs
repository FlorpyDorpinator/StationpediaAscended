using StationpediaAscended.Data;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for logic types, modes, connections, and slot logic.
    /// </summary>
    public class SPDALogicTooltip : SPDABaseTooltip
    {
        private string _logicTypeName;
        private string _categoryName;

        public void Initialize(string deviceKey, string logicTypeName, string categoryName)
        {
            _deviceKey = deviceKey;
            _logicTypeName = logicTypeName;
            _categoryName = categoryName;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            string cleanName = CleanName(_logicTypeName);
            
            if (_categoryName == "Mode")
            {
                var modeDesc = StationpediaAscendedMod.GetModeDescription(_deviceKey, cleanName);
                if (modeDesc != null)
                {
                    _cachedTooltipText = FormatModeTooltip(cleanName, modeDesc);
                    return _cachedTooltipText;
                }
            }
            else if (_categoryName == "Connection")
            {
                var connDesc = StationpediaAscendedMod.GetConnectionDescription(_deviceKey, cleanName);
                if (connDesc != null)
                {
                    _cachedTooltipText = FormatLogicTooltip(cleanName, connDesc);
                    return _cachedTooltipText;
                }
            }
            else if (_categoryName == "LogicSlot")
            {
                var slotLogicDesc = StationpediaAscendedMod.GetSlotLogicDescription(cleanName);
                if (slotLogicDesc != null)
                {
                    _cachedTooltipText = FormatSlotLogicTooltip(cleanName, slotLogicDesc);
                    return _cachedTooltipText;
                }
                var desc = StationpediaAscendedMod.GetLogicDescription(_deviceKey, cleanName);
                if (desc != null)
                {
                    _cachedTooltipText = FormatLogicTooltip(cleanName, desc);
                    return _cachedTooltipText;
                }
            }
            else
            {
                var desc = StationpediaAscendedMod.GetLogicDescription(_deviceKey, cleanName);
                if (desc != null)
                {
                    _cachedTooltipText = FormatLogicTooltip(cleanName, desc);
                    return _cachedTooltipText;
                }
            }
            
            _cachedTooltipText = $"<color=#FFA500><b>{cleanName}</b></color>\n\n" +
                                 $"<color=#AAAAAA>No detailed description available yet.</color>\n" +
                                 $"<color=#666666>Device: {_deviceKey}</color>";
            return _cachedTooltipText;
        }

        private static string FormatLogicTooltip(string cleanName, LogicDescription desc)
        {
            return $"<color=#FFA500><b>{cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<b>Type:</b> {desc.dataType}   <b>Range:</b> {desc.range}\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{desc.description}";
        }
        
        private static string FormatModeTooltip(string cleanName, ModeDescription desc)
        {
            return $"<color=#9932CC><b>Mode: {cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{desc.description}";
        }

        private static string FormatSlotLogicTooltip(string cleanName, string description)
        {
            return $"<color=#FFA500><b>Slot: {cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<b>Type:</b> LogicSlot   <b>Slots:</b> All readable slots\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{description}";
        }
    }
}
