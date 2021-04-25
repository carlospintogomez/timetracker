using System;

namespace timetracker
{
    public class IsActiveEventArgs : EventArgs
    {
        public TimeSpan ActiveTime { get; set; }
        public bool IsActive { get; set; }
    }
}