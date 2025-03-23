using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

public static class UserHandler
{
    public static HashSet<string> ConnectedIds = new HashSet<string>();
}



[Authorize]
public class MatchHub : Hub
{

    ApplicationDbContext _context;
    MatchesService _matchesService;

  
    public MatchHub(ApplicationDbContext context, MatchesService matchesService) 
    {
        _context = context;
        _matchesService = matchesService;
    }
    private string signalRUserId
    {
        get { return Context.ConnectionId!; }
    }

    private string groupName(int? matchId)
    {
        return $"Match_{matchId}";
    }




    //Connexion
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

  
    //Join Match
    public async Task onJoinMatchAsync(string userId, string? connectionId, int? specificMatchId)
    {
        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

        if (joiningMatchData != null)
        {
            await Clients.Client(signalRUserId).SendAsync("JoiningMatchData", joiningMatchData);

            string PlayerAUserId = joiningMatchData.PlayerA.UserId;
            string OtherPlayerId = joiningMatchData.OtherPlayerConnectionId;
            int MatchId = joiningMatchData.Match.Id;

            // On envoie les bonnes données à l'autre joueur.
            JoiningMatchData? joiningMatchDataOtherPlayer = await _matchesService.JoinMatch(PlayerAUserId,OtherPlayerId,MatchId);


            await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("joiningMatch", joiningMatchDataOtherPlayer);
        }
        else
        {
            await Clients.Client(signalRUserId).SendAsync("LookingForOtherPlayer", "Waiting on another player for match.");
        }
    }

    //Start Match
    public async Task onStartMatchAsync(Match match)
    {
        var startMatchEvent = await _matchesService.StartMatch(signalRUserId, match);

        await Groups.AddToGroupAsync(signalRUserId, groupName(match.Id));

        await Clients.Clients(signalRUserId).SendAsync("StartMatch", startMatchEvent);
    }

    //End Turn
    public async Task onEndTurnAsync(string userId, int matchId)
    {
        var EndTurnEvent = await _matchesService.EndTurn(userId, matchId);

        await Clients.Group(groupName(matchId)).SendAsync("EndTurn", EndTurnEvent);
    }


    //Surrender
    public async Task onSurrenderAsync(string userId,int matchId)
    {
        var SurrenderEvent = await _matchesService.Surrender(userId, matchId);

        await Clients.Group(groupName(matchId)).SendAsync("Surrender", SurrenderEvent);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page