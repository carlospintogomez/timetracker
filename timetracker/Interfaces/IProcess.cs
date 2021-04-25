namespace timetracker
{
    public interface IProcess
    {
        public bool IsActive();
        public string GetProcessName();
    }
}
