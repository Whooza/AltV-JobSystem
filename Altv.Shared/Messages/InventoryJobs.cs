using Altv.Shared.Messages.NestedData;
using AltvJobSystem.Shared;
using System.Text.Json.Serialization;

namespace Altv.Shared.Messages;

public struct InvGetJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; set; }

    [JsonConstructor]
    public InvGetJob(string cbEvent)
    {
        CbEvent = cbEvent;
    }
}

public readonly struct InvGetReply : IReply
{
    [JsonPropertyName("0")] public ItemInfo[] Items { get; }

    [JsonConstructor]
    public InvGetReply(ItemInfo[] items)
    {
        Items = items;
    }
}

public readonly struct InvMoveJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
    [JsonPropertyName("1")] public int To { get; }
    [JsonPropertyName("2")] public int Item { get; }
    [JsonPropertyName("3")] public int Amount { get; }

    [JsonConstructor]
    public InvMoveJob(string cbEvent, int to, int item, int amount)
    {
        CbEvent = cbEvent;
        To = to;
        Item = item;
        Amount = amount;
    }
}
public readonly struct InvUseJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
    [JsonPropertyName("1")] public int Item { get; }

    [JsonConstructor]
    public InvUseJob(string cbEvent, int item)
    {
        CbEvent = cbEvent;
        Item = item;
    }
}
public readonly struct InvDestroyJob : IJob
{
    [JsonPropertyName("0")] public string CbEvent { get; }
    [JsonPropertyName("1")] public int Item { get; }
    [JsonPropertyName("2")] public int Amount { get; }

    [JsonConstructor]
    public InvDestroyJob(string cbEvent, int item, int amount)
    {
        CbEvent = cbEvent;
        Item = item;
        Amount = amount;
    }
}