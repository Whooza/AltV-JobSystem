using Altv.Shared.Messages.NestedData;
using AltvJobSystem.Shared;
using System.Text.Json.Serialization;

namespace Altv.Shared.Messages;

public readonly struct TeamGetUsersJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }

    [JsonConstructor]
    public TeamGetUsersJob(string cbEvent)
    {
        CbEvent = cbEvent;
    }
}

public readonly struct TeamGetUsersReply : IReply
{
    [JsonPropertyName("0")] public UserInfo[] Users { get; }

    [JsonConstructor]
    public TeamGetUsersReply(UserInfo[] users)
    {
        Users = users;
    }
}

public readonly struct TeamAddMarkJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
}

public readonly struct TeamDelMarkJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
}

public readonly struct TeamResetBioJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
}

public readonly struct TeamSpawnVehJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
}

public readonly struct TeamRepairVehJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
}