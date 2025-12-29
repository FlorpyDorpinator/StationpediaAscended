using StationpediaAscended.Data;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for physical slot types (Battery, Plant, etc.).
    /// </summary>
    public class SPDASlotTooltip : SPDABaseTooltip
    {
        private string _slotName;

        public void Initialize(string deviceKey, string slotName)
        {
            _deviceKey = deviceKey;
            _slotName = slotName;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            string cleanName = CleanName(_slotName);
            var desc = StationpediaAscendedMod.GetSlotDescription(_deviceKey, cleanName);
            
            if (desc != null)
            {
                _cachedTooltipText = FormatTooltip(cleanName, desc);
                return _cachedTooltipText;
            }
            
            _cachedTooltipText = $"<color=#00BFFF><b>{cleanName}</b></color>\n\n" +
                                 $"<color=#AAAAAA>No slot description available yet.</color>";
            return _cachedTooltipText;
        }

        private static string FormatTooltip(string cleanName, SlotDescription desc)
        {
            return $"<color=#00BFFF><b>Slot: {cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<b>Type:</b> {desc.slotType}\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{desc.description}";
        }
    }
}
