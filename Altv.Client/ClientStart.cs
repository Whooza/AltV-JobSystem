global using Altv.Client.JobClients;
global using Altv.Shared.Messages;
global using Altv.Shared.Messages.GenericReplies;
global using Altv.Shared.Messages.NestedData;
global using AltV.Net.Client;
global using AltvJobSystem.Client;
global using AltvJobSystem.Shared;

namespace Altv.Client;

public class ClientStart : Resource
{
    private readonly InventoryClient _inventoryClient;
    private readonly ILogging<ClientStart> _logger;
    private readonly TeamClient _teamClient;

    public ClientStart()
    {
        _inventoryClient = new(new ClientLogger<InventoryClient>());
        _teamClient = new(new ClientLogger<TeamClient>());
        _logger = new ClientLogger<ClientStart>();
    }

    public override async void OnStart()
    {
        _inventoryClient.Start();
        _teamClient.Start();

        InvGetReply getTeply = await _inventoryClient.Get(new InvGetJob(InventoryClient.GetCbEvent()));

        foreach (ItemInfo item in getTeply.Items)
        {
            _logger.Log(LoggerLevel.Info, $"### item: {item.Item} amount: {item.Amount} ###");
        }

        TeamGetUsersReply getUsersReply = await _teamClient.GetUsers(new TeamGetUsersJob(InventoryClient.GetCbEvent()));

        _logger.LogRaw("Online Users:");

        foreach (UserInfo user in getUsersReply.Users)
        {
            _logger.Log(LoggerLevel.Info, $"[User]: name: '{user.Name}' ping: '{user.Ping}' scid: '{user.SocialClubId}'");
        }

        _logger.Log(LoggerLevel.Info, "started");
    }

    public override void OnStop()
    {
        _logger.Log(LoggerLevel.Info, "stopped");
    }
}
