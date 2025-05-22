using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using Super_Cartes_Infinies.Services;
using System.Text.RegularExpressions;

namespace Super_Cartes_Infinies.Hubs;

public static class UserHandler
{
    public static HashSet<string> ConnectedIds = new HashSet<string>();
    
    // Ajout d.un dictionnaire
    public static Dictionary<string, string> UserConnections { get; set; } = new Dictionary<string, string>();

}



[Authorize]
public class MatchHub : Hub
{

    ApplicationDbContext _context;
    MatchesService _matchesService;
    PlayersService _playersService;
    WaitingUserService _waitingUserService;


  
    public MatchHub(ApplicationDbContext context, MatchesService matchesService, PlayersService playersService, WaitingUserService waitingUserService) 
    {
        _context = context;
        _matchesService = matchesService;
        _playersService = playersService;
        _waitingUserService = waitingUserService;
    }
   



    //Connexion
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public string MatchGroup(int id)
    {
        return "match_" + id;
    }

    private string userId { get { return Context.UserIdentifier; } }
    private string connectionId { get { return Context.ConnectionId; } }



    //Join Match
    public async Task onJoinMatchAsync(int? specificMatchId)
    {
        string? connectionId = Context.ConnectionId;
        string userId = Context.UserIdentifier;

        // Check if the user is a spectator
        if (specificMatchId.HasValue)
        {
            var match = await _context.Matches.Include(a => a.PlayerDataA).Include(b => b.PlayerDataB).SingleOrDefaultAsync(x => x.Id == specificMatchId.Value);

            if (match != null)
            {
                var Player1Id = match.PlayerDataA.Id.ToString();
                var Player2Id = match.PlayerDataB.Id.ToString();

                // Vérifier si il est spectateur
                if (userId != Player1Id && userId != Player2Id)
                {
                    await JoinMatchAsSpectator(specificMatchId.Value);
                    return;
                }

            }
        }

        // Check for ongoing match
        if (specificMatchId != null)
        {
            var joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

            if (joiningMatchData != null)
            {
                string groupName = MatchGroup(joiningMatchData.Match.Id);

                await Groups.AddToGroupAsync(connectionId, groupName);

                if (joiningMatchData.OtherPlayerConnectionId != null)
                {
                    await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName);
                }

                await Clients.Group(groupName).SendAsync("JoiningMatchAsSpectator", joiningMatchData);

            }
        }
        else
        {
            var playerInfo = new PlayerInfo
            {
                ConnectionId = connectionId,
                UserId = userId,
                ELO = _playersService.GetPlayerFromUserId(userId).ELO, //A voir si sa fonctionne :(
                WaitTimeSeconds = 0
            };

            _waitingUserService.AddPlayer(playerInfo);
        }

        //JoiningMatchData? joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

        if (specificMatchId != null)
        {
            //CreateChannel(specificMatchId.Value);
        

            // V�rifier si c'est un visiteur ou player

            //    await Groups.AddToGroupAsync(connectionId,joiningMatchData.Match.Id.ToString());

            //    if(joiningMatchData.OtherPlayerConnectionId!=null)
            //    await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, joiningMatchData.Match.Id.ToString());

            //    //await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("JoiningMatchData", joiningMatchData);

            // await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("StartMatch", startMatchEvent);
            

        }
        else
        {
            await Clients.Client(connectionId).SendAsync("LookingForOtherPlayer", "Waiting on another player for match.");
        }
    }
    // Signal R CHAT
    // Permet d'afficher la liste des matches qui sont joué en ce moment
    public async Task SeeOngoingGame()
    {
        var ongoingMatches = _context.Matches.Where(m => m.IsMatchCompleted == false).Include(p => p.PlayerDataA).Include(p => p.PlayerDataB).ToList();
        await Clients.Caller.SendAsync("SeeOngoingGame", ongoingMatches);
    }

    // Permet de rejoindre un match en tant que spectateur
    private async Task JoinMatchAsSpectator(int specificMatchId)
    {
        var DataSpectator = await _matchesService.JoinMatchAsSpectator(userId, specificMatchId);
        string groupName = MatchGroup(specificMatchId);
        await Groups.AddToGroupAsync(connectionId, groupName);
        await Clients.Client(connectionId).SendAsync("WatchAnOngoingMatch", DataSpectator);

        await Clients.Group(groupName).SendAsync("newSpectatorJoinedMessage", DataSpectator);
    }


    public async Task WatchAnOngoingMatch(int specificMatchId)
    {
        JoiningMatchData joiningMatchData = await _matchesService.JoinMatchAsSpectator(userId, specificMatchId);
        string groupName = MatchGroup(specificMatchId);
        await Groups.AddToGroupAsync(connectionId, groupName);
        await Clients.Client(connectionId).SendAsync("WatchAnOngoingMatch", joiningMatchData);
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
    ////
    ////
    ////
    ////
    //// Va chercher le user qui est connecter
    //public IdentityUser CurrentUser
    //{
    //    get
    //    {
    //        string userId = Context.UserIdentifier;
    //        var user = _context.Users.Single(u => u.Id == userId);
    //        return user;
    //    }
    //}

    //// D�connexion
    //public async override Task OnDisconnectedAsync(Exception? exception)
    //{
    //    KeyValuePair<string, string> entrie = UserHandler.UserConnections.SingleOrDefault(uc => uc.Value == Context.UserIdentifier);
    //    UserHandler.UserConnections.Remove(entrie.Key);
    //    await UserList();
    //}

    //public async Task UserList()
    //{
    //    await Clients.All.SendAsync("UsersList", UserHandler.UserConnections.ToList());
    //}

    //public async Task JoinChat()
    //{
    //    UserHandler.UserConnections.Add(CurrentUser.Email!, Context.UserIdentifier);
    //    await UserList();
    //    await Clients.Caller.SendAsync("ChannelsList", _context.Channel.ToListAsync());
    //}

    //playCard
    public async Task onPlayCardAsync(int matchId,int CardBeingPlayedId)
    {
        string userId = Context.UserIdentifier!;
        var playCardEvent = await _matchesService.PlayCard(userId, CardBeingPlayedId, matchId);

        await Clients.Group(matchId.ToString()).SendAsync("PlayCard", playCardEvent);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page