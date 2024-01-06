using AltV.Net.Client;
using AltvJobSystem.Shared;
using System.Collections.Concurrent;
using System.Text.Json;

namespace AltvJobSystem.Client;

public abstract class JobClientBase<TClient> where TClient : class
{
    protected readonly ILogging<TClient> Logger;
    protected readonly ConcurrentDictionary<string, ConcurrentDictionary<string, TaskCompletionSource<string>>> Replies;

    protected JobClientBase(ILogging<TClient> logger)
    {
        Logger = logger;
        Replies = new();
    }

    public abstract void Start();

    public static string GetCbEvent()
    {
        string[] cbEvent = Guid.NewGuid().ToString().Split('-');
        return cbEvent[0] + cbEvent[4];
    }

    protected async Task<TReply> Request<TJob, TReply>(TJob job) where TJob : struct, IJob where TReply : struct, IReply
    {
        TaskCompletionSource<string> tcs = new();
        TReply reply = default;

        if (Replies[typeof(TJob).Name.ToLower()].TryAdd(job.CbEvent, tcs))
        {
            Alt.EmitServer(typeof(TJob).Name.ToLower(), JsonSerializer.Serialize(job));
            reply = JsonSerializer.Deserialize<TReply>(await tcs.Task);
            _ = Replies.TryRemove(job.CbEvent, out _);
        }

        return reply;
    }

    protected void RegisterMethod<TJob, TReply>(Func<TJob, Task<TReply>> logic) where TJob : struct, IJob where TReply : struct, IReply
    {
        string typeEventName = typeof(TJob).Name.ToLower();
#if DEBUG
        Logger.Log(LoggerLevel.Debug, $"Register event '{typeEventName}'");
#endif
        if (!Replies.ContainsKey(typeEventName) && Replies.TryAdd(typeEventName, new()))
        {
            Alt.OnServer(typeEventName, (string cbEvent, string replyString) =>
            {
#if DEBUG
                Logger.Log(LoggerLevel.Debug, $"received data: {replyString}");
#endif
                if (Replies[typeEventName].TryGetValue(cbEvent, out TaskCompletionSource<string> tcs))
                {
                    tcs.SetResult(replyString);
                }
            });
        }
    }
}
