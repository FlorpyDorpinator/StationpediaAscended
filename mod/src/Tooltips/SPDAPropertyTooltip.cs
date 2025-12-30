using StationpediaAscended.Data;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for material/atmospheric property values like Flashpoint, Autoignition, etc.
    /// </summary>
    public class SPDAPropertyTooltip : SPDABaseTooltip
    {
        private string _propertyName;

        public void Initialize(string propertyName)
        {
            _propertyName = propertyName;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            var desc = StationpediaAscendedMod.GetPropertyDescription(_propertyName);
            if (desc != null)
            {
                _cachedTooltipText = FormatPropertyTooltip(_propertyName, desc);
                return _cachedTooltipText;
            }

            _cachedTooltipText = $"<color=#FFA500><b>{_propertyName}</b></color>\n\n" +
                                 $"<color=#AAAAAA>No detailed description available yet.</color>";
            return _cachedTooltipText;
        }

        private static string FormatPropertyTooltip(string propertyName, PropertyDescription desc)
        {
            string formattedText = $"<color=#FFA500><b>{propertyName}</b></color>\n" +
                                   $"<color=#888888>─────────────────────</color>\n";

            if (!string.IsNullOrEmpty(desc.type))
            {
                formattedText += $"<b>Type:</b> {desc.type}\n";
            }

            if (!string.IsNullOrEmpty(desc.threshold))
            {
                formattedText += $"<b>Threshold:</b> {desc.threshold}\n";
            }

        formattedText += $"<color=#888888>─────────────────────</color>\n" +
                            $"{desc.description}";

            if (!string.IsNullOrEmpty(desc.formula))
            {
                formattedText += $"\n\n<color=#888888><i>Formula: {desc.formula}</i></color>";
            }

            return formattedText;
        }
    }
}
