namespace AltvJobSystem.Shared;

public interface ILogging<T> where T : class
{
    void LogRaw(string message);
    void Log(LoggerLevel level, string message);
}