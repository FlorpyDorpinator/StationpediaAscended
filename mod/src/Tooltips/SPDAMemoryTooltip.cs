using StationpediaAscended.Data;

namespace StationpediaAscended.Tooltips
{
    /// <summary>
    /// Tooltip component for IC memory instructions.
    /// </summary>
    public class SPDAMemoryTooltip : SPDABaseTooltip
    {
        private string _instructionName;

        public void Initialize(string deviceKey, string instructionName)
        {
            _deviceKey = deviceKey;
            _instructionName = instructionName;
            _cachedTooltipText = null;
        }

        protected override string GetTooltipText()
        {
            if (_cachedTooltipText != null)
                return _cachedTooltipText;

            string cleanName = CleanInstructionName(_instructionName);
            var desc = StationpediaAscendedMod.GetMemoryDescription(_deviceKey, cleanName);
            
            if (desc != null)
            {
                _cachedTooltipText = FormatTooltip(cleanName, desc);
                return _cachedTooltipText;
            }
            
            _cachedTooltipText = $"<color=#FF69B4><b>{cleanName}</b></color>\n\n" +
                                 $"<color=#AAAAAA>No instruction description available yet.</color>";
            return _cachedTooltipText;
        }

        private static string FormatTooltip(string cleanName, MemoryDescription desc)
        {
            string paramText = string.IsNullOrEmpty(desc.parameters) ? "none" : desc.parameters;
            string tooltip = $"<color=#FF69B4><b>Instruction: {cleanName}</b></color>\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"<b>OpCode:</b> {desc.opCode}\n" +
                   $"<b>Parameters:</b> {paramText}\n" +
                   $"<color=#888888>─────────────────────</color>\n" +
                   $"{desc.description}";
            
            if (!string.IsNullOrEmpty(desc.byteLayout))
            {
                tooltip += $"\n<color=#888888>─────────────────────</color>\n" +
                          $"<color=#AAAAAA><b>Byte Layout:</b></color>\n{desc.byteLayout}";
            }
            
            return tooltip;
        }

        /// <summary>
        /// Cleans instruction name, removing HTML tags and OP_CODE suffix.
        /// </summary>
        private static string CleanInstructionName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            
            string cleaned = CleanName(name);
            
            int opCodeIndex = cleaned.IndexOf(" OP_CODE:");
            if (opCodeIndex > 0)
            {
                cleaned = cleaned.Substring(0, opCodeIndex).Trim();
            }
            
            return cleaned;
        }
    }
}
