using AltV.Net.Client;
using AltvJobSystem.Shared;

namespace AltvJobSystem.Client;

public class ClientLogger<TType> : LoggerBase<TType> where TType : class
{
    protected override void Write(string message)
    {
        Alt.Log(message);
    }
}
