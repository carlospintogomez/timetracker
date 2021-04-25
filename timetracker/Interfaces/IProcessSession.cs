using System;

namespace timetracker
{
    public interface IProcessSession
    {
        public string GetSessionName();
        public TimeSpan GetTotalActiveTime();
    }
}