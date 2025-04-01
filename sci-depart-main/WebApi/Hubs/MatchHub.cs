using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Text.RegularExpressions;

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
    public async Task onJoinMatchAsync(int? specificMatchId)
    {
        string? connectionId = Context.ConnectionId;
        string userId = Context.UserIdentifier;

        JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

        if (joiningMatchData != null)
        {
            await Clients.Client(connectionId).SendAsync("JoiningMatchData", joiningMatchData);
            if(joiningMatchData.OtherPlayerConnectionId != null)
            {
                await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("JoiningMatchData", joiningMatchData);
            }
            //await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("JoiningMatchData", joiningMatchData);



            if (!joiningMatchData.IsStarted)
            {
                var startMatchEvent = await _matchesService.StartMatch(userId, joiningMatchData.Match);

                await Groups.AddToGroupAsync(connectionId, groupName(joiningMatchData.Match.Id));
                await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName(joiningMatchData.Match.Id));


                await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("StartMatch", startMatchEvent);
                await Clients.Client(connectionId).SendAsync("StartMatch", startMatchEvent);

               // await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("StartMatch", startMatchEvent);
            }
        }
        else
        {
            await Clients.Client(connectionId).SendAsync("LookingForOtherPlayer", "Waiting on another player for match.");
        }
    }

 

    //End Turn
    public async Task onEndTurnAsync( int matchId)
    {
        string userId = Context.UserIdentifier;
        var EndTurnEvent = await _matchesService.EndTurn(userId, matchId);

        await Clients.Group(groupName(matchId)).SendAsync("EndTurn", EndTurnEvent);
    }


    //Surrender
    public async Task onSurrenderAsync(int matchId)
       
    {
        string userId = Context.UserIdentifier;
        var SurrenderEvent = await _matchesService.Surrender(userId, matchId);

        await Clients.Group(groupName(matchId)).SendAsync("Surrender", SurrenderEvent);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page