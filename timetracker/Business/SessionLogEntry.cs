using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class SessionLogEntry
    {
        public event EventHandler<ActiveThresholdReachedEventArgs> ActiveThresholdReached;
        public TimeSpan TotalActiveTime { get; set; }
        public string SessionName { get; set; }
    }
}
