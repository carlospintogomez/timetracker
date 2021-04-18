using System;
using System.Collections.Generic;

namespace timetracker
{
    public class SessionLog : ISessionLog
    {
        public Dictionary<DateTime, IProcessSession> SessionLogDictionary { get; }

        public SessionLog()
        {
            SessionLogDictionary = new Dictionary<DateTime, IProcessSession>();
        }

        public void PersistSession(ISessionManager sessionManager)
        {
            var today = DateTime.Today;
            if (SessionLogDictionary.ContainsKey(today))
            {
                SessionLogDictionary[today] = sessionManager.SquashSession(SessionLogDictionary[today]);
            }
            else
            {
                SessionLogDictionary.Add(today, sessionManager.GetSession());
            }
        }
    }
}
