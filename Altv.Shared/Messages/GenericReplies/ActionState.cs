using AltvJobSystem.Shared;
using System.Text.Json.Serialization;

namespace Altv.Shared.Messages.GenericReplies;

public readonly struct ActionState : IReply
{
    [JsonPropertyName("0")] public bool Success { get; }
    [JsonPropertyName("1")] public string JsonData { get; }

    [JsonConstructor]
    public ActionState(bool success, string message)
    {
        Success = success;
        JsonData = message;
    }
}