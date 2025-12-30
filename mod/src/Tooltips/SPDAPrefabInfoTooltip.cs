using UnityEngine;
using UnityEngine.EventSystems;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for Prefab Name and Prefab Hash fields.
    /// Shows full value (in case truncated), click-to-copy instruction, and IC10 usage info.
    /// </summary>
    public class SPDAPrefabInfoTooltip : SPDABaseTooltip
    {
        private string _fullValue;
        private bool _isPrefabHash;

        /// <summary>
        /// Initialize the tooltip with the field info.
        /// </summary>
        /// <param name="deviceKey">The device key for reference</param>
        /// <param name="fullValue">The full prefab name or hash value</param>
        /// <param name="isPrefabHash">True if this is Prefab Hash, false if Prefab Name</param>
        public void Initialize(string deviceKey, string fullValue, bool isPrefabHash)
        {
            _deviceKey = deviceKey;
            _fullValue = fullValue;
            _isPrefabHash = isPrefabHash;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            if (_isPrefabHash)
            {
                _cachedTooltipText = FormatPrefabHashTooltip(_fullValue);
            }
            else
            {
                _cachedTooltipText = FormatPrefabNameTooltip(_fullValue);
            }
            
            return _cachedTooltipText;
        }

        private static string FormatPrefabNameTooltip(string prefabName)
        {
            return $"<color=#FFA500><b>Prefab Name</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<color=#00BFFF>{prefabName}</color>\n\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<color=#90EE90><b>Click to copy</b></color>\n\n" +
                   $"<color=#AAAAAA>Used in IC10 programming to identify this device type.\n" +
                   $"Can be used interchangeably with Prefab Hash.\n\n" +
                   $"Example: <color=#FFA500>lb r0 {TruncateForExample(prefabName)} Setting</color></color>";
        }

        private static string FormatPrefabHashTooltip(string prefabHash)
        {
            return $"<color=#FFA500><b>Prefab Hash</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<color=#00BFFF>{prefabHash}</color>\n\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<color=#90EE90><b>Click to copy</b></color>\n\n" +
                   $"<color=#AAAAAA>Numeric identifier for this device type in IC10.\n" +
                   $"Can be used interchangeably with Prefab Name.\n\n" +
                   $"Example: <color=#FFA500>lb r0 {prefabHash} Setting</color></color>";
        }

        /// <summary>
        /// Truncates long prefab names for display in tooltip examples.
        /// </summary>
        private static string TruncateForExample(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            // Clean the link formatting first
            name = CleanName(name);
            if (name.Length > 25)
                return name.Substring(0, 22) + "...";
            return name;
        }
    }
}
