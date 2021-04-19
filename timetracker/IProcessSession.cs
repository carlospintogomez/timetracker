using System;

namespace timetracker
{
    public interface IProcessSession
    {
        public void AddActiveTime(TimeSpan activeTime);
        public string GetSessionName();
        public TimeSpan GetActiveTime();
    }
}