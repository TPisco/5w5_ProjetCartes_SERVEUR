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
            await Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, joiningMatchData.Match.Id.ToString());

            //await Clients.Group(joiningMatchData.Match.Id.ToString()).SendAsync("JoiningMatchData", joiningMatchData);

            if (specificMatchId != null)
            {
                CreateChannel(specificMatchId.Value);
            }

            // Vérifier si c'est un visiteur ou player

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

    // Déconnexion
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
        // Pas besoin de créer un modèle Channel, car on ne veut pas sauvegarder les messages 

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

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page