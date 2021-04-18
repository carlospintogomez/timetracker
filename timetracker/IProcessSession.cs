using System;

namespace timetracker
{
    public interface IProcessSession
    {
        public void SaveActiveTime(TimeSpan activeTime);
        public string GetSessionName();
        public TimeSpan GetActiveTime();
    }
}