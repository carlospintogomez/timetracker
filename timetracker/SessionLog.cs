using System;
using System.Collections.Generic;

namespace timetracker
{
    public class SessionLog : ISessionLog
    {
        public Dictionary<string, IProcessSession> Entries { get; set; }

        public SessionLog()
        {
            Entries = new Dictionary<string, IProcessSession>();
        }

        public void SquashSession(string key, IProcessSession processSession)
        {
            if (!Entries.ContainsKey(key))
            {
                Entries[key] = new ProcessSession
                {
                    ActiveTime = processSession.GetActiveTime(),
                    SessionName = processSession.GetSessionName()
                };
            } 
            else if (!Entries[key].GetSessionName().Equals(processSession.GetSessionName()))
            {
                throw new InvalidOperationException("Cannot add two sessions have different process names");
            }
            else
            {
                Entries[key] = new ProcessSession
                {
                    ActiveTime = Entries[key].GetActiveTime() + processSession.GetActiveTime(),
                    SessionName = processSession.GetSessionName()
                };
            }
        }
    }
}
