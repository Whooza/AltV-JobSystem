using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltvJobSystem.Shared;
using System.Text.Json;

namespace AltvJobSystem.Server;

public abstract class JobHubBase<THub> where THub : class
{
    protected readonly ILogging<THub> Logger;

    protected JobHubBase(ILogging<THub> logger)
    {
        Logger = logger;
    }

    public abstract void Start();

    [Obsolete]
    protected void RegisterMethod<TJob, TReply>(Func<TJob, Task<TReply>> logic) where TJob : struct, IJob where TReply : struct, IReply
    {
        string typeEventName = typeof(TJob).Name.ToLower();
#if DEBUG
        Logger.Log(LoggerLevel.Debug, $"Register event '{typeEventName}'");
#endif
        AltAsync.OnClient<IPlayer, string>(typeEventName, async (player, jobString) =>
        {
#if DEBUG
            Logger.Log(LoggerLevel.Debug, $"received data: {jobString}");
#endif
            TJob job = JsonSerializer.Deserialize<TJob>(jobString);
            TReply reply = await logic.Invoke(job);
            string replyString = JsonSerializer.Serialize(reply);
            await player.EmitAsync(typeEventName, job.CbEvent, replyString);
        });
    }
}
