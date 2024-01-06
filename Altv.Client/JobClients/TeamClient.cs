using AltvJobSystem.Shared;

namespace Altv.Client.JobClients;

internal class TeamClient : JobClientBase<TeamClient>, ITeamLogic
{
    public TeamClient(ILogging<TeamClient> logger) : base(logger)
    {
    }

    public async Task<ActionState> AddMark(TeamAddMarkJob addMarkJob)
    {
        return await Request<TeamAddMarkJob, ActionState>(addMarkJob).ConfigureAwait(false);
    }

    public async Task<ActionState> DeleteMark(TeamDelMarkJob deleteMarkJob)
    {
        return await Request<TeamDelMarkJob, ActionState>(deleteMarkJob).ConfigureAwait(false);
    }

    public async Task<TeamGetUsersReply> GetUsers(TeamGetUsersJob getUsersJob)
    {
        return await Request<TeamGetUsersJob, TeamGetUsersReply>(getUsersJob).ConfigureAwait(false);
    }

    public async Task<ActionState> RepairVehicle(TeamRepairVehJob repairVehJob)
    {
        return await Request<TeamRepairVehJob, ActionState>(repairVehJob).ConfigureAwait(false);
    }

    public async Task<ActionState> ResetBio(TeamResetBioJob resetBioJob)
    {
        return await Request<TeamResetBioJob, ActionState>(resetBioJob).ConfigureAwait(false);
    }

    public async Task<ActionState> SpawnVehicle(TeamSpawnVehJob spawnVehJob)
    {
        return await Request<TeamSpawnVehJob, ActionState>(spawnVehJob).ConfigureAwait(false);
    }

    public override void Start()
    {
        RegisterMethod<TeamAddMarkJob, ActionState>(AddMark);
        RegisterMethod<TeamDelMarkJob, ActionState>(DeleteMark);
        RegisterMethod<TeamGetUsersJob, TeamGetUsersReply>(GetUsers);
        RegisterMethod<TeamRepairVehJob, ActionState>(RepairVehicle);
        RegisterMethod<TeamResetBioJob, ActionState>(ResetBio);
        RegisterMethod<TeamSpawnVehJob, ActionState>(SpawnVehicle);
    }
}
