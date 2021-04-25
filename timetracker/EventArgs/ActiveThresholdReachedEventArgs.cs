using System;

namespace timetracker
{
    public class ActiveThresholdReachedEventArgs : EventArgs
    {
        public TimeSpan ActiveTime { get; set; }
        public bool ActiveThresholdReached { get; set; }
    }
}
