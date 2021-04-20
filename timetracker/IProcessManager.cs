using System;

namespace timetracker
{
    public interface IProcessManager
    {
        public TimeSpan PollActiveTime();
        public IProcess GetProcess();
    }
}
