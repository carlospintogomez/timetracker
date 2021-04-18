using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class ProcessSession : IProcessSession
    {
        private TimeSpan _activeTime;
        private readonly string _sessionName;

        public ProcessSession(string sessionName)
        {
            _sessionName = sessionName;
        }

        public string GetSessionName()
        {
            return _sessionName;
        }

        public TimeSpan GetActiveTime()
        {
            return _activeTime;
        }

        public void SaveActiveTime(TimeSpan activeTime)
        {
            _activeTime += activeTime;
            Console.WriteLine("Process Total Active Time: " + _activeTime);
        }
    }
}
