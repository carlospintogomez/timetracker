using System;

namespace timetracker
{
    public class ProcessFoundEventArgs : EventArgs
    {
        public ProcessWrapper ProcessWrapper { get; set; }
    }
}
