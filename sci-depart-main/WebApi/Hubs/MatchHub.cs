using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using Models.Models;
using Super_Cartes_Infinies.Combat;
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



public class MatchHub : Hub
{

    ApplicationDbContext _context;
    MatchesService _matchesService;
    PlayersService _playersService;
    WaitingUserService _waitingUserService;
    UserManager<IdentityUser> _userManager;
    MatchRewardsService _matchRewardsService;


  
    public MatchHub(ApplicationDbContext context, MatchesService matchesService, PlayersService playersService, WaitingUserService waitingUserService, UserManager<IdentityUser> userManager, MatchRewardsService matchRewardsService) 
    {
        _context = context;
        _matchesService = matchesService;
        _playersService = playersService;
        _waitingUserService = waitingUserService;
        _userManager = userManager;
        _matchRewardsService = matchRewardsService;
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


    public async Task<IdentityUser> GetCurrentUserAsync()
    {
        string userId = Context.UserIdentifier!;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("Utilisateur introuvable.");
        }

        return user;
    }

    //Join Match
    [Authorize]
    public async Task onJoinMatchAsync(int? specificMatchId)
    {
        string? connectionId = Context.ConnectionId;
        string userId = GetCurrentUserAsync().Result.Id;

        // Check if the user is banned from the chat
        if (specificMatchId != null)
        {
            Super_Cartes_Infinies.Models.Match match = _context.Matches.FirstOrDefault(m => m.Id == specificMatchId);

            if (match == null)
            {
                await Clients.Caller.SendAsync("Error", $"Match avec l'ID {specificMatchId} introuvable.");
                return;
            }

            if (match.BannedSpectatorIds != null && match.BannedSpectatorIds.Contains(GetCurrentUserAsync().Result.Email))
            {
                await Clients.Caller.SendAsync("BannedFromMatch", match.Id);
                return;
            }
        }
        else
        {
            await Clients.Client(connectionId).SendAsync("LookingForOtherPlayer", "Waiting on another player for match.");
        }


        try
        {
            var matchData = await  _matchesService.JoinMatch(userId, connectionId, specificMatchId);

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (matchData != null)
            {
                string groupName = $"match_{matchData.Match.Id}";
                await Groups.AddToGroupAsync(connectionId, groupName);

                bool isSpectator =
                    (matchData.PlayerA == null || matchData.PlayerA.UserId != userId) &&
                    (matchData.PlayerB == null || matchData.PlayerB.UserId != userId);


                if (isSpectator)
                {
                    if (!matchData.Match.SpectatorIds.Contains(userId))
                    {
                        matchData.Match.SpectatorIds.Add(userId);
                        _context.Matches.Update(matchData.Match);
                        await _context.SaveChangesAsync();
                    }

                    // Broadcast that user joined
                    await Clients.Group(groupName).SendAsync("PlayerJoined", user.Email);

                    var updatedMatch = await _context.Matches
                        .Include(m => m.PlayerDataA)
                            .ThenInclude(pda => pda.Player)
                        .Include(m => m.PlayerDataB)
                            .ThenInclude(pdb => pdb.Player)
                        .FirstOrDefaultAsync(m => m.Id == matchData.Match.Id);

                    await Clients.Client(connectionId).SendAsync("JoiningMatchData", new JoiningMatchData
                    {
                        Match = updatedMatch!,
                        PlayerA = updatedMatch.PlayerDataA.Player,
                        PlayerB = updatedMatch.PlayerDataB.Player
                    });
                }
                else
                {
                    if (!matchData.IsStarted)
                    {
                        await Groups.AddToGroupAsync(matchData.OtherPlayerConnectionId, groupName);
                    }

                    await Clients.Group(groupName).SendAsync("JoiningMatchData", matchData);
                    await Clients.Group(groupName).SendAsync("PlayerJoined", user.Email);

                    if (!matchData.IsStarted)
                    {
                        StartMatchEvent startedMatch = await _matchesService.StartMatch(userId, matchData.Match);
                        await Clients.Group(groupName).SendAsync("PlayEvent", startedMatch);
                    }
                }
            }
            else if (specificMatchId != null)
            {
                var leMatch = await _context.Matches
                    .Include(m => m.PlayerDataA)
                        .ThenInclude(pdA => pdA.Player)
                    .Include(m => m.PlayerDataB)
                        .ThenInclude(pdB => pdB.Player)
                    .FirstOrDefaultAsync(m => m.Id == specificMatchId);

                if (leMatch != null && leMatch.UserAId != userId && leMatch.UserBId != userId)
                {
                    if (!leMatch.SpectatorIds.Contains(user.Email))
                    {
                        leMatch.SpectatorIds.Add(user.Email);
                        _context.Matches.Update(leMatch);
                        await _context.SaveChangesAsync();
                        JoinMatchGroup(leMatch.Id);

                        string groupName = $"match_{leMatch.Id}";
                        await Clients.Group(groupName).SendAsync("PlayerJoined", user.Email);
                    }

                    await Clients.Client(connectionId).SendAsync("JoiningMatchData", new JoiningMatchData
                    {
                        Match = leMatch,
                        PlayerA = leMatch.PlayerDataA.Player,
                        PlayerB = leMatch.PlayerDataB.Player
                    });
                }
            }
        }
        catch (Exception ex)
        {
            await Clients.Client(connectionId).SendAsync("Error", $"Erreur arrive quand joindre match: {ex.Message}");
        }
    }
    // Signal R CHAT
    // Permet d'afficher la liste des matches qui sont joué en ce moment
    [AllowAnonymous]
    public async Task SeeOngoingGame()
    {
        var ongoingMatches = _context.Matches
            .Where(m => m.IsMatchCompleted == false)
            .Include(p => p.PlayerDataA).ThenInclude(pd => pd.Player)
            .Include(p => p.PlayerDataB).ThenInclude(pd => pd.Player)
            .ToList();
        await Clients.Caller.SendAsync("SeeOngoingGame", ongoingMatches);
    }

    [AllowAnonymous]
    public async Task WatchMatchAsync(int matchId)
    {
        var match = await _context.Matches
            .Include(m => m.PlayerDataA).ThenInclude(pd => pd.Player)
            .Include(m => m.PlayerDataB).ThenInclude(pd => pd.Player)
            .FirstOrDefaultAsync(m => m.Id == matchId && !m.IsMatchCompleted);

        if (match == null)
        {
            await Clients.Caller.SendAsync("Error", $"Match avec l'ID {matchId} introuvable ou terminé.");
            return;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, MatchGroup(matchId));
        await Clients.Caller.SendAsync("JoiningMatchData", new JoiningMatchData
        {
            Match = match,
            PlayerA = match.PlayerDataA.Player,
            PlayerB = match.PlayerDataB.Player
        });
    }

    // Bannir les spectateurs
    [Authorize]
    public async Task BanUser(int matchId, string userEmail)
    {
        Super_Cartes_Infinies.Models.Match match = _context.Matches.FirstOrDefault(m => m.Id == matchId);
        var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

        if (match == null)
        {
            return;
        }
        else
        {
            if (!match.BannedSpectatorIds.Contains(userEmail))
            {
                match.BannedSpectatorIds.Add(userEmail);
                _context.Matches.Update(match);
                await _context.SaveChangesAsync();
                await Clients.All.SendAsync("BannedFromMatchWithId", match.Id, userEmail);

            }
            if (match.SpectatorIds.Contains(userEmail))
            {
                match.SpectatorIds.Remove(userEmail);
            }
        }

    }

    public async Task LeaveMatch(int matchId, string userEmail)
    {
        Super_Cartes_Infinies.Models.Match match = _context.Matches.FirstOrDefault(m => m.Id == matchId);
        var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
        if (match == null)
        {
            return;
        }
        else
        {
            if (match.SpectatorIds.Contains(userEmail))
            {

                if (match.SpectatorIds.Contains(userEmail))
                {
                    match.SpectatorIds.Remove(userEmail);
                    _context.Matches.Update(match);
                    await _context.SaveChangesAsync();
                    await Clients.Group($"match_{match.Id}").SendAsync("PlayerLeft");
                }

            }
        }

    }

    public async Task JoinMatchGroup(int matchId)
    {
        string groupName = $"match_{matchId}";
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessage(int matchId, string sender, string message, string role)
    {
        string groupName = $"match_{matchId}";
        await Clients.Group(groupName).SendAsync("ReceiveChatMessage", sender, message, role);
    }




    [Authorize]
    public async Task onEndTurnAsync(int matchId)
    {
        string? userId = Context.UserIdentifier;
        if (string.IsNullOrEmpty(userId))
            throw new HubException("Utilisateur non authentifié.");

        var endTurnEvent = await _matchesService.EndTurn(userId, matchId);

        await Clients.Group(MatchGroup(matchId)).SendAsync("EndTurn", endTurnEvent);
        await TryApplyRewardsAsync(matchId);
    }


    //Surrender
    [Authorize]
    public async Task onSurrenderAsync(int matchId)
    {
        string? userId = Context.UserIdentifier;
        if (string.IsNullOrEmpty(userId))
            throw new HubException("Utilisateur non authentifié.");

        var surrenderEvent = await _matchesService.Surrender(userId, matchId);

        await Clients.Group(MatchGroup(matchId)).SendAsync("Surrender", surrenderEvent);
        await TryApplyRewardsAsync(matchId);
    }

    [Authorize]
    public async Task onPlayCardAsync(int matchId,int CardBeingPlayedId)
    {
        string userId = Context.UserIdentifier!;
        var playCardEvent = await _matchesService.PlayCard(userId, CardBeingPlayedId, matchId);

        await Clients.Group(MatchGroup(matchId)).SendAsync("PlayCard", playCardEvent);
        await TryApplyRewardsAsync(matchId);
    }

    private async Task TryApplyRewardsAsync(int matchId)
    {
        var match = await _context.Matches
            .Include(m => m.PlayerDataA)
            .Include(m => m.PlayerDataB)
            .FirstOrDefaultAsync(m => m.Id == matchId);

        if (match?.IsMatchCompleted != true || string.IsNullOrEmpty(match.WinnerUserId))
            return;

        var winningPlayerId = match.UserAId == match.WinnerUserId
            ? match.PlayerDataA.PlayerId
            : match.PlayerDataB.PlayerId;

        await _matchRewardsService.ApplyMatchEndRewardsAsync(matchId, winningPlayerId);
    }

}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page