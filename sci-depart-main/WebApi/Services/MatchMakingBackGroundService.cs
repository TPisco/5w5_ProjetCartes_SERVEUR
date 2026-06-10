using Microsoft.AspNetCore.SignalR;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using Super_Cartes_Infinies.Services;
using System.Threading;

namespace WebApi.Services
{
    public class MatchMakingBackGroundService : BackgroundService
    {
        public const int DELAY = 1 * 1000;

        private const int CONSTANTE = 10;

        private IServiceScopeFactory _serviceScopeFactory;

        private IHubContext<MatchHub> _matchHub;




        public class PairOfPlayers
        {
            public PlayerInfo Player1 { get; }
            public PlayerInfo Player2 { get; }

            public PairOfPlayers(PlayerInfo player1, PlayerInfo player2)
            {
                Player1 = player1;
                Player2 = player2;
            }
        }

        public MatchMakingBackGroundService(IHubContext<MatchHub> matchHub, IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory = serviceScopeFactory;
            _matchHub = matchHub;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(DELAY, stoppingToken);
                await DoSomething(stoppingToken);
            }
        }

        public async Task DoSomething(CancellationToken stoppingToken) 
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {

            
                MatchesService _matchesService = scope.ServiceProvider.GetRequiredService<MatchesService>();
                WaitingUserService _waitingUserService = scope.ServiceProvider.GetRequiredService<WaitingUserService>();


                List<PlayerInfo> waitingPlayers = _waitingUserService.GetWaitingPlayersSnapshot();



                var pairs = GeneratePairs(waitingPlayers);

                foreach (var pair in pairs)
                {
                    // Remove matched players from waiting list
                    _waitingUserService.RemovePlayer(pair.Player1.UserId);
                    _waitingUserService.RemovePlayer(pair.Player2.UserId);

                    // Call JoinMatch for each player to generate or retrieve the match
                    var joiningMatchData1 = await _matchesService.JoinMatch(pair.Player1.UserId, pair.Player1.ConnectionId, null);
                    var joiningMatchData = await _matchesService.JoinMatch(pair.Player2.UserId, pair.Player2.ConnectionId, null);

                    if (joiningMatchData != null)
                    {
                        // Send match info to each client
                        await _matchHub.Clients.Client(pair.Player2.ConnectionId).SendAsync("JoiningMatchData", joiningMatchData, stoppingToken);
                        if (joiningMatchData.OtherPlayerConnectionId != null)
                        {
                            await _matchHub.Clients.Client(joiningMatchData.OtherPlayerConnectionId).SendAsync("JoiningMatchData", joiningMatchData, stoppingToken);
                        }

                        // Add both to SignalR group
                        string groupName = $"match_{joiningMatchData.Match.Id}";
                        await _matchHub.Groups.AddToGroupAsync(pair.Player2.ConnectionId, groupName, stoppingToken);
                        if (joiningMatchData.OtherPlayerConnectionId != null)
                        {
                            await _matchHub.Groups.AddToGroupAsync(joiningMatchData.OtherPlayerConnectionId, groupName, stoppingToken);
                        }

                        // Start the match if ready
                        if (!joiningMatchData.IsStarted)
                        {
                            StartMatchEvent startMatchEvent = await _matchesService.StartMatch(pair.Player2.UserId, joiningMatchData.Match);
                            await _matchHub.Clients.Group(groupName).SendAsync("PlayEvent", startMatchEvent, stoppingToken);
                        }
                    }
                }

            }

        }

       

        public List<PairOfPlayers> GeneratePairs(List<PlayerInfo> playerInfos)
        {
            var pairs = new List<PairOfPlayers>();

            // On travaille sur une copie car on va modifier la liste
            var players = new List<PlayerInfo>(playerInfos);

            while (players.Count > 0)
            {
                var player = players[0];
                players.RemoveAt(0);

                int smallestELODifference = int.MaxValue;
                int bestMatchIndex = -1;

                for (int i = 0; i < players.Count; i++)
                {
                    var candidate = players[i];
                    int difference = Math.Abs(candidate.ELO - player.ELO);

                    if (difference < player.WaitTimeSeconds * CONSTANTE)
                    {
                        if (difference < smallestELODifference)
                        {
                            smallestELODifference = difference;
                            bestMatchIndex = i;
                        }
                    }
                }

                if (bestMatchIndex >= 0)
                {
                    var match = players[bestMatchIndex];
                    players.RemoveAt(bestMatchIndex);
                    pairs.Add(new PairOfPlayers(player, match));
                }
                // Sinon, le joueur est ignoré pour ce cycle
                player.WaitTimeSeconds++;
            }

            return pairs;
        }
    

       
    }
}
