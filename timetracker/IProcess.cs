namespace timetracker
{
    public interface IProcess
    {
        public bool HasExited();
        public bool IsActive();
        public string GetProcessName();
    }
}
