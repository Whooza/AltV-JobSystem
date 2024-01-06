using AltvJobSystem.Shared;

namespace Altv.Server.JobHubs;

internal class InventoryHub : JobHubBase<InventoryHub>, IInventoryLogic
{
    public InventoryHub(ILogging<InventoryHub> logger) : base(logger)
    {
    }

    public Task<InvGetReply> Get(InvGetJob invGetJob)
    {
        ItemInfo[] invItems = new ItemInfo[]
        {
            new("apple", 7),
            new("water", 4)
        };

        return Task.FromResult(new InvGetReply(invItems));
    }

    public Task<ActionState> Use(InvUseJob useJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<ActionState> Move(InvMoveJob moveJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<ActionState> Destroy(InvDestroyJob destroyJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    [Obsolete]
    public override void Start()
    {
        RegisterMethod<InvGetJob, InvGetReply>(Get);
        RegisterMethod<InvUseJob, ActionState>(Use);
        RegisterMethod<InvMoveJob, ActionState>(Move);
        RegisterMethod<InvDestroyJob, ActionState>(Destroy);
    }
}