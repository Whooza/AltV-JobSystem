using System.Text.Json.Serialization;

namespace Altv.Shared.Messages.NestedData;

public readonly struct UserInfo
{
    [JsonPropertyName("0")] public string Name { get; }
    [JsonPropertyName("1")] public uint Ping { get; }
    [JsonPropertyName("2")] public ulong SocialClubId { get; }

    [JsonConstructor]
    public UserInfo(string name, uint ping, ulong socialClubId)
    {
        Name = name;
        Ping = ping;
        SocialClubId = socialClubId;
    }
}
