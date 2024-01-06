using Altv.Shared.Messages.GenericReplies;

namespace Altv.Shared.Messages;

public interface ITeamLogic
{
    Task<TeamGetUsersReply> GetUsers(TeamGetUsersJob getUsersJob);
    Task<ActionState> AddMark(TeamAddMarkJob addMarkJob);
    Task<ActionState> DeleteMark(TeamDelMarkJob deleteMarkJob);
    Task<ActionState> ResetBio(TeamResetBioJob resetBioJob);
    Task<ActionState> SpawnVehicle(TeamSpawnVehJob spawnVehJob);
    Task<ActionState> RepairVehicle(TeamRepairVehJob repairVehJob);
}
