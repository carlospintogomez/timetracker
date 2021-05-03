using System;

namespace timetracker
{
    public class IsInactiveEventArgs : EventArgs
    {
        public TimeSpan TotalActiveTime { get; set; }
        public bool IsInactive { get; set; }
    }
}