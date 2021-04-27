using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class ProcessSession : IProcessSession
    {
        //TODO: maybe use a SessionLog object to contain many of these fields?
        public event EventHandler<ActiveThresholdReachedEventArgs> ActiveThresholdReached;
        public TimeSpan ActiveTimeLimit { get; set; }
        public TimeSpan TotalActiveTime { get; set; }
        public string SessionName { get; set; }
        public event EventHandler<SessionEndedEventArgs> SessiongEnded;
        public ProcessWatcher ProcessWatcher { get; }
        public string Category { get; set; }

        public ProcessSession(ProcessWatcher processWatcher)
        {
            ProcessWatcher = processWatcher;
        }

        // TODO: move all methods into a ProcessSessionManager class
        public void StartSession()
        {
            ProcessWatcher.Exited += Exited;
            ProcessWatcher.IsActive += IsActive;
            ProcessWatcher.PollActive();
        }

        private void Exited(object source, ExitedEventArgs e)
        {
            TotalActiveTime = e.TotalActiveTime;
            Console.WriteLine("Process Total Active Time: " + TotalActiveTime);
            var sessionEndedEventArgs = new SessionEndedEventArgs
            {
                ProcessSession = this
            };
            OnSessionEnded(sessionEndedEventArgs);
        }

        private void IsActive(object source, IsActiveEventArgs e)
        {
            if (e.ActiveTime > ActiveTimeLimit)
            {
                var activeThresholdReacherEventArgs = new ActiveThresholdReachedEventArgs
                {
                    ActiveThresholdReached = true,
                    ActiveTime = e.ActiveTime,
                    ProcessSession = this
                };
                OnActiveThresholdReached(activeThresholdReacherEventArgs);
            }
        }

        public string GetSessionName()
        {
            return SessionName;
        }

        public TimeSpan GetTotalActiveTime()
        {
            return TotalActiveTime;
        }

        public void OnSessionEnded(SessionEndedEventArgs e)
        {
            SessiongEnded?.Invoke(this, e);
        }

        public void OnActiveThresholdReached(ActiveThresholdReachedEventArgs e)
        {
            ActiveThresholdReached?.Invoke(this, e);
        }
    }
}
