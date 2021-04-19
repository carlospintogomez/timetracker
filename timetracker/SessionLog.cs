using System;
using System.Collections.Generic;

namespace timetracker
{
    public class SessionLog : ISessionLog
    {
        public List<IProcessSession> Sessions { get; set; }

        public SessionLog()
        {
            Sessions = new List<IProcessSession>();
        }
    }
}
