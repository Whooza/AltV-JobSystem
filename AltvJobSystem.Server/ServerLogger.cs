using AltV.Net.Async;
using AltvJobSystem.Shared;

namespace AltvJobSystem.Server;

public class ServerLogger<TType> : LoggerBase<TType> where TType : class
{
    protected override void Write(string message)
    {
        AltAsync.Log(message);
    }
}
