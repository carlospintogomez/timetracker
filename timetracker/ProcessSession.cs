using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class ProcessSession : IProcessSession
    {
        public TimeSpan ActiveTime { get; set; }
        public string SessionName { get; set; }
        public DateTime EndTime { get; set; }

        public string GetSessionName()
        {
            return SessionName;
        }

        public TimeSpan GetActiveTime()
        {
            return ActiveTime;
        }
    }
}
