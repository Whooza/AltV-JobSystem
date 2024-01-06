global using Altv.Server.JobHubs;
global using Altv.Shared.Messages;
global using Altv.Shared.Messages.GenericReplies;
global using Altv.Shared.Messages.NestedData;
global using AltV.Net;
global using AltV.Net.Async;
global using AltV.Net.Elements.Entities;
global using AltvJobSystem.Server;
global using AltvJobSystem.Shared;

namespace Altv.Server;

public class ServerStart : AsyncResource
{
    private readonly ILogging<ServerStart> _logger;
    private readonly InventoryHub _inventoryHub;
    private readonly TeamHub _teamHub;

    public ServerStart()
    {
        _inventoryHub = new(new ServerLogger<InventoryHub>());
        _teamHub = new(new ServerLogger<TeamHub>());
        _logger = new ServerLogger<ServerStart>();
    }

    public override void OnStart()
    {
        _inventoryHub.Start();
        _teamHub.Start();
        _logger.Log(LoggerLevel.Info, "started");
    }

    public override void OnStop()
    {
        _logger.Log(LoggerLevel.Info, "stopped");
    }
}
