using System;
using System.Collections.Generic;

namespace timetracker
{
    public class SessionLog : ISessionLog
    {
        public Dictionary<string, SessionLogEntry> Entries { get; set; }

        public SessionLog()
        {
            Entries = new Dictionary<string, SessionLogEntry>();
        }

        public void SquashSession(string key, IProcessSession processSession)
        {
            if (!Entries.ContainsKey(key))
            {
                Entries[key] = new SessionLogEntry
                {
                    TotalActiveTime = processSession.GetTotalActiveTime(),
                    SessionName = processSession.GetSessionName()
                };
            } 
            else if (!Entries[key].SessionName.Equals(processSession.GetSessionName()))
            {
                throw new InvalidOperationException("Cannot add two sessions have different process names");
            }
            else
            {
                Entries[key] = new SessionLogEntry
                {
                    TotalActiveTime = Entries[key].TotalActiveTime + processSession.GetTotalActiveTime(),
                    SessionName = processSession.GetSessionName()
                };
            }
        }
    }
}
