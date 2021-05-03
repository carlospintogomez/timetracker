using System;

namespace timetracker
{
    public class ProcessWatcher : IProcessWatcher
    {
        public event EventHandler<ExitedEventArgs> Exited;
        public event EventHandler<IsActiveEventArgs> IsActive;
        public event EventHandler<IsInactiveEventArgs> IsInactive;
        public TimeSpan ActiveTimeSensitivity { get; set; }
        public ProcessWrapper ProcessWrapper { get; }

        public ProcessWatcher(ProcessWrapper processWrapper)
        {
            ProcessWrapper = processWrapper;
        }

        public void PollActive()
        {
            Console.WriteLine($"Process {ProcessWrapper.GetProcessName()} is now active. Recording...");
            var totalActiveTime = TimeSpan.FromSeconds(0);
            System.Threading.Tasks.Task.Run(() =>
            {
                while (!ProcessWrapper.HasExited())
                {
                    var beforeActiveTime = DateTime.Now;
                    var activeTime = TimeSpan.FromSeconds(0);
                    while (ProcessWrapper.IsActive())
                    {
                        activeTime = DateTime.Now - beforeActiveTime;
                        var isActiveEventArgs = new IsActiveEventArgs
                        {
                            IsActive = true,
                            ActiveTime = activeTime
                        };
                        OnIsActive(isActiveEventArgs);
                        System.Threading.Thread.Sleep(ActiveTimeSensitivity.Milliseconds);
                    }
                    totalActiveTime += activeTime;
                    if(activeTime != TimeSpan.FromSeconds(0))
                    {
                        var isInactiveEventArgs = new IsInactiveEventArgs
                        {
                            IsInactive = true,
                            TotalActiveTime = totalActiveTime
                        };
                        OnIsInactive(isInactiveEventArgs);
                    }
                }
                var exitedEventArgs = new ExitedEventArgs
                {
                    Exited = true,
                    TotalActiveTime = totalActiveTime
                };
                OnExited(exitedEventArgs);
            });
        }

        public void OnIsActive(IsActiveEventArgs e)
        {
            IsActive?.Invoke(this, e);
        }

        public void OnIsInactive(IsInactiveEventArgs e)
        {
            IsInactive?.Invoke(this, e);
        }

        public void OnExited(ExitedEventArgs e)
        {
            Exited?.Invoke(this, e);
        }
    }
}
