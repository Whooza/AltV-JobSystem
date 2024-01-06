using AltvJobSystem.Shared;

namespace Altv.Server.JobHubs;

internal class TeamHub : JobHubBase<TeamHub>, ITeamLogic
{
    public TeamHub(ILogging<TeamHub> logger) : base(logger)
    {
    }

    public Task<ActionState> AddMark(TeamAddMarkJob addMarkJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<ActionState> DeleteMark(TeamDelMarkJob deleteMarkJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<TeamGetUsersReply> GetUsers(TeamGetUsersJob getUsersJob)
    {
        IPlayer[] players = Alt.GetAllPlayers().ToArray();
        int playerCount = players.Length;
        UserInfo[] users = new UserInfo[playerCount];

        for (int i = 0; i < playerCount; i++)
        {
            IPlayer player = players[i];
            users[i] = new(player.Name, player.Ping, player.SocialClubId);
        }

        TeamGetUsersReply reply = new(users);

        return Task.FromResult(reply);
    }

    public Task<ActionState> RepairVehicle(TeamRepairVehJob repairVehJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<ActionState> ResetBio(TeamResetBioJob resetBioJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    public Task<ActionState> SpawnVehicle(TeamSpawnVehJob spawnVehJob)
    {
        return Task.FromResult(new ActionState(true, string.Empty));
    }

    [Obsolete]
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
