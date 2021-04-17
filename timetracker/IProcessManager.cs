using System;

namespace timetracker
{
    public interface IProcessManager
    {
        public TimeSpan ComputeActiveTime();
    }
}
