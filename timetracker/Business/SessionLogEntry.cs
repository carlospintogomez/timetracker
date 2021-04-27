using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class SessionLogEntry
    {
        // TODO: there's some similarity between this class and ProcessSession. Interface? Abstract?
        public string Category { get; set; }
        public TimeSpan TotalActiveTime { get; set; }
        public string SessionName { get; set; }
    }
}
