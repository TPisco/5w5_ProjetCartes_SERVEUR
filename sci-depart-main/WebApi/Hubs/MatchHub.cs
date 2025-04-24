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
            if (joiningMatchData.OtherPlayerConnectionId != null)
            {
                await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("JoiningMatchData", joiningMatchData);
            }

            await Groups.AddToGroupAsync(connectionId,joiningMatchData.Match.Id.ToString());

            if(joiningMatchData.OtherPlayerConnectionId!=null)
            await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, joiningMatchData.Match.Id.ToString());

            //await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("JoiningMatchData", joiningMatchData);



            if (!joiningMatchData.IsStarted)
            {
                var startMatchEvent = await _matchesService.StartMatch(userId, joiningMatchData.Match);


                //await Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("StartMatch", startMatchEvent);
                //await Clients.Client(connectionId).SendAsync("StartMatch", startMatchEvent);

               await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("StartMatch", startMatchEvent);
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


        if (EndTurnEvent == null)
        {
            throw new InvalidOperationException("Failed to end the turn");
        }

        await Clients.Group(matchId.ToString()).SendAsync("EndTurn", EndTurnEvent);

    }


    //Surrender
    public async Task onSurrenderAsync(int matchId)
    {
        string userId = Context.UserIdentifier;
        var SurrenderEvent = await _matchesService.Surrender(userId, matchId);

        await Clients.Group(matchId.ToString()).SendAsync("Surrender", SurrenderEvent);
    }


    //playCard
    public async Task onPlayCardAsync(int matchId,int CardBeingPlayedId)
    {
        string userId = Context.UserIdentifier!;
        var playCardEvent = _matchesService.PlayCard(userId, CardBeingPlayedId, matchId);

        await Clients.Group(matchId.ToString()).SendAsync("PlayCard", playCardEvent);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page