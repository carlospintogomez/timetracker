using System;

namespace timetracker
{
    /// <summary>
    /// Process Session object saves all activity occuring for a given time/transaction.
    /// </summary>
    public class ProcessSession : IProcessSession
    {
        public event EventHandler<ActiveThresholdReachedEventArgs> ActiveThresholdReached;
        public TimeSpan ActiveTimeLimit { get; set; }
        public TimeSpan TotalActiveTime { get; set; }
        public string SessionName { get; set; }
        public event EventHandler<SessionEndedEventArgs> SessiongEnded;
        public ProcessWatcher ProcessWatcher { get; }
        private DateTime _endTime;

        public ProcessSession(ProcessWatcher processWatcher)
        {
            ProcessWatcher = processWatcher;
        }

        public void StartSession()
        {
            ProcessWatcher.Exited += Exited;
            ProcessWatcher.IsActive += IsActive;
            ProcessWatcher.PollActive();
        }

        private void Exited(object source, ExitedEventArgs e)
        {
            TotalActiveTime = e.TotalActiveTime;
            _endTime = DateTime.Now;
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
                    ActiveTime = e.ActiveTime
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

        public DateTime GetEndTime()
        {
            return _endTime;
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
