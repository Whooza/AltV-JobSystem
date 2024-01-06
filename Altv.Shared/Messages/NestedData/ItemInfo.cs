using System.Text.Json.Serialization;

namespace Altv.Shared.Messages.NestedData;

public readonly struct ItemInfo
{
    [JsonPropertyName("0")] public string Item { get; }
    [JsonPropertyName("1")] public int Amount { get; }

    [JsonConstructor]
    public ItemInfo(string item, int amount)
    {
        Item = item;
        Amount = amount;
    }
}
