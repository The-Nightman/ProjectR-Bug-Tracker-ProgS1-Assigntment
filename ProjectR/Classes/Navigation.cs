namespace ProjectR.Classes
{
    /// <summary>
    /// Navigation Object providing a source of pseudo navigation
    /// </summary>
    /// <param name="navTargetPanel">The Panel control to target as the "navigation window"</param>
    public class Navigation(Panel navTargetPanel)
    {
        private readonly Panel _navigationTargetPanel = navTargetPanel;
        private readonly List<UserControl> _history = [];

        public List<UserControl> History
        {
            get => _history;
        }

        /// <summary>
        /// Clear and Add controls to the target panel control set when the object is initialized and add the control to the history providing pseudo navigation
        /// </summary>
        /// <param name="screen">The UserControl component to switch into the Panel "navigation window"</param>
        public void UseNavigate(UserControl screen)
        {
            _history.Add(screen);
            //? Is there a way to do this without the memory climbing at all?
            _navigationTargetPanel.Controls.Clear();
            _navigationTargetPanel.Controls.Add(screen);
        }

        /// <summary>
        /// Navigate in reverse to the last control stored in internal history
        /// </summary>
        public void UseBackNavigate()
        {
            _history.RemoveAt(_history.Count - 1);
            //? Is there a way to do this without the memory climbing at all?
            _navigationTargetPanel.Controls.Clear();
            _navigationTargetPanel.Controls.Add(_history[^1]);
        }
    }
}
