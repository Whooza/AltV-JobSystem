namespace AltvJobSystem.Shared;

public abstract class LoggerBase<TType> : ILogging<TType> where TType : class
{
    private readonly string _sysName;

    public LoggerBase()
    {
        _sysName = typeof(TType).Name;
    }

    public void LogRaw(string message)
    {
        Write($"[{_sysName}|{DateTime.Now.ToShortTimeString()}]: {message}");
    }

    public void Log(LoggerLevel level, string message)
    {
        Write($"[{_sysName}|{DateTime.Now.ToShortTimeString()}|{level}]: {message}");
    }

    protected abstract void Write(string message);
}