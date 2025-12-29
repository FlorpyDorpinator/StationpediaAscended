using StationpediaAscended.Data;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for build versions (Tier One, Tier Two, etc.).
    /// </summary>
    public class SPDAVersionTooltip : SPDABaseTooltip
    {
        private string _versionName;

        public void Initialize(string deviceKey, string versionName)
        {
            _deviceKey = deviceKey;
            _versionName = versionName;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            string cleanName = CleanName(_versionName);
            var desc = StationpediaAscendedMod.GetVersionDescription(_deviceKey, cleanName);
            
            if (desc != null)
            {
                _cachedTooltipText = FormatTooltip(cleanName, desc);
                return _cachedTooltipText;
            }
            
            _cachedTooltipText = $"<color=#90EE90><b>{cleanName}</b></color>\n\n" +
                                 $"<color=#AAAAAA>No version description available yet.</color>";
            return _cachedTooltipText;
        }

        private static string FormatTooltip(string cleanName, VersionDescription desc)
        {
            return $"<color=#90EE90><b>Version: {cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{desc.description}";
        }
    }
}
