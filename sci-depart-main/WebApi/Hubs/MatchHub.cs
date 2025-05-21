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

  
    //Join Match
    public async Task onJoinMatchAsync(int? specificMatchId)
    {
        string? connectionId = Context.ConnectionId;
        string userId = Context.UserIdentifier;



        


        // Check for ongoing match
        if (specificMatchId != null)
        {
            var joiningMatchData = await _matchesService.JoinMatch(userId, connectionId, specificMatchId);

            if (joiningMatchData != null)
            {
                await Clients.Client(connectionId).SendAsync("JoiningMatchData", joiningMatchData);

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
            CreateChannel(specificMatchId.Value);
        

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
    //
    //
    //
    //
    // Va chercher le user qui est connecter
    public IdentityUser CurrentUser
    {
        get
        {
            string userId = Context.UserIdentifier;
            var user = _context.Users.Single(u => u.Id == userId);
            return user;
        }
    }

    // D�connexion
    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        KeyValuePair<string, string> entrie = UserHandler.UserConnections.SingleOrDefault(uc => uc.Value == Context.UserIdentifier);
        UserHandler.UserConnections.Remove(entrie.Key);
        await UserList();
    }

    public async Task UserList()
    {
        await Clients.All.SendAsync("UsersList", UserHandler.UserConnections.ToList());
    }


    // Signal R CHAT
    private async Task SeeOngoingGame()
    {
        var ongoingMatches = await _context.Matches.SingleOrDefaultAsync(m => m.IsMatchCompleted == false);
        await Clients.All.SendAsync("SeeOngoingGame", ongoingMatches);
    }

    private async Task JoinChat()
    {
        UserHandler.UserConnections.Add(CurrentUser.Email!, Context.UserIdentifier);
        await UserList();
        await Clients.Caller.SendAsync("ChannelsList", _context.Channel.ToListAsync());
    }

    public async Task SendMessage(string message, int channelId, string userId)
    {

        if (channelId != 0)
        {
            string groupName = CreateChannelGroupName(channelId);
            Channel channel = _context.Channel.Find(channelId);
            await Clients.Group(groupName).SendAsync("NewMessage", "[" + CurrentUser.UserName + "] " + message);
        }
    }

    private static string CreateChannelGroupName(int channelId)
    {
        return "Channel" + channelId;
    }

    public async Task CreateChannel(int matchId)
    {
        // Pas besoin de cr�er un mod�le Channel, car on ne veut pas sauvegarder les messages 

         var channel = new Channel { Name = matchId.ToString(), MatchId = matchId };
        string groupName = CreateChannelGroupName(matchId);
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        

         _context.Channel.Add(channel);

         await _context.SaveChangesAsync();

         await Clients.Caller.SendAsync("Channel", channel);
    }

    public async Task JoinChannel(int oldChannelId, int newChannelId)
    {
        string userTag = "[" + CurrentUser.UserName! + "]";

        if (oldChannelId > 0)
        {
            string oldGroupName = CreateChannelGroupName(oldChannelId);
            Channel channel = _context.Channel.Find(oldChannelId);
            string message = userTag + " quitte: " + channel.Name;
            await Clients.Group(oldGroupName).SendAsync("NewMessage", message);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, oldGroupName);
        }

        if (newChannelId > 0)
        {
            string newGroupName = CreateChannelGroupName(newChannelId);
            await Groups.AddToGroupAsync(Context.ConnectionId, newGroupName);

            Channel channel = _context.Channel.Find(newChannelId);
            string message = userTag + " a rejoint : " + channel.Name;
            await Clients.Group(newGroupName).SendAsync("NewMessage", message);
        }
    }


    //playCard
    public async Task onPlayCardAsync(int matchId,int CardBeingPlayedId)
    {
        string userId = Context.UserIdentifier!;
        var playCardEvent = await _matchesService.PlayCard(userId, CardBeingPlayedId, matchId);

        await Clients.Group(matchId.ToString()).SendAsync("PlayCard", playCardEvent);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page