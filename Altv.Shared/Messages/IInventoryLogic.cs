using Altv.Shared.Messages.GenericReplies;

namespace Altv.Shared.Messages;

public interface IInventoryLogic
{
    Task<InvGetReply> Get(InvGetJob getJob);
    Task<ActionState> Use(InvUseJob useJob);
    Task<ActionState> Move(InvMoveJob moveJob);
    Task<ActionState> Destroy(InvDestroyJob destroyJob);
}
