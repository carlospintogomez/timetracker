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

        public ProcessSession(string sessionName)
        {
            SessionName = sessionName;
        }

        public string GetSessionName()
        {
            return SessionName;
        }

        public TimeSpan GetActiveTime()
        {
            return ActiveTime;
        }

        public void AddActiveTime(TimeSpan activeTime)
        {
            ActiveTime = GetActiveTime() + activeTime;
            EndTime = DateTime.Now;
            Console.WriteLine("Process Total Active Time: " + ActiveTime);
        }
    }
}
