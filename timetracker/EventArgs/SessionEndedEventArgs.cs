using System;

namespace timetracker
{
    public class SessionEndedEventArgs : EventArgs
    {
        public ProcessSession ProcessSession { get; set; }
    }
}
