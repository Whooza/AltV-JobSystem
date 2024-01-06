using AltvJobSystem.Shared;

namespace Altv.Client.JobClients;

internal class InventoryClient : JobClientBase<InventoryClient>, IInventoryLogic
{
    public InventoryClient(ILogging<InventoryClient> logger) : base(logger)
    {
    }

    public async Task<InvGetReply> Get(InvGetJob getJob)
    {
        return await Request<InvGetJob, InvGetReply>(getJob).ConfigureAwait(false);
    }

    public async Task<ActionState> Use(InvUseJob useJob)
    {
        return await Request<InvUseJob, ActionState>(useJob).ConfigureAwait(false);
    }

    public async Task<ActionState> Move(InvMoveJob moveJob)
    {
        return await Request<InvMoveJob, ActionState>(moveJob).ConfigureAwait(false);
    }

    public async Task<ActionState> Destroy(InvDestroyJob destroyJob)
    {
        return await Request<InvDestroyJob, ActionState>(destroyJob).ConfigureAwait(false);
    }

    public override void Start()
    {
        RegisterMethod<InvGetJob, InvGetReply>(Get);
        RegisterMethod<InvUseJob, ActionState>(Use);
        RegisterMethod<InvMoveJob, ActionState>(Move);
        RegisterMethod<InvDestroyJob, ActionState>(Destroy);
    }
}
