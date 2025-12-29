namespace StationpediaAscended.Core
{
    /// <summary>
    /// Centralized state management for tooltip display.
    /// All tooltip components read/write through these properties.
    /// </summary>
    public static class TooltipState
    {
        /// <summary>
        /// The current tooltip text to display.
        /// </summary>
        public static string CurrentText { get; set; } = "";

        /// <summary>
        /// Whether to show the tooltip.
        /// </summary>
        public static bool IsVisible { get; set; } = false;

        /// <summary>
        /// Shows a tooltip with the specified text.
        /// </summary>
        public static void Show(string text)
        {
            CurrentText = text;
            IsVisible = true;
        }

        /// <summary>
        /// Hides the tooltip and clears the text.
        /// </summary>
        public static void Hide()
        {
            CurrentText = "";
            IsVisible = false;
        }

        /// <summary>
        /// Resets the tooltip state (for cleanup/reload).
        /// </summary>
        public static void Reset()
        {
            CurrentText = "";
            IsVisible = false;
        }
    }
}
