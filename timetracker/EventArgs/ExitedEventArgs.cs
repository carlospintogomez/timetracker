using System;

namespace timetracker
{
    public class ExitedEventArgs : EventArgs
    {
        public TimeSpan TotalActiveTime { get; set; }
        public bool Exited { get; set; }
    }
}
