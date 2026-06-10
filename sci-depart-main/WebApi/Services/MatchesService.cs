using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Models.Dtos;
using WebApi.Combat;

namespace Super_Cartes_Infinies.Services
{
	public class MatchesService
    {
        private WaitingUserService _waitingUserService;
        private PlayersService _playersService;
        private CardsService _cardsService;
        private MatchConfigurationService _matchConfigurationService;
        private DecksService _decksService;
        private ApplicationDbContext _dbContext;

        public MatchesService(ApplicationDbContext context, WaitingUserService waitingUserService, PlayersService playersService, CardsService cardsService, MatchConfigurationService matchConfigurationService, DecksService decksService)        {
            _dbContext = context;
            _waitingUserService = waitingUserService;
            _playersService = playersService;
            _cardsService = cardsService;
            _matchConfigurationService = matchConfigurationService;
            _decksService = decksService;
        }

        // Cette fonction est assez flexible car elle peut simplement être appeler lorsqu'un user veut jouer un match
        // Si le user a déjà un match en cours (Un match qui n'est pas terminé), on lui retourne l'information pour ce match
        // Sinon on utilise le WaitingUserService pour essayer de trouver un autre user ou nous mettre en attente
        public async Task<JoiningMatchData?> JoinMatch(string userId, string? connectionId, int? specificMatchId)
        {
            // Vérifier si le match n'a pas déjà été démarré (de façon plus générale, retourner un match courrant si le joueur y participe)
            IEnumerable<Match> matches = _dbContext.Matches.Where(m => m.IsMatchCompleted == false && (m.UserAId == userId || m.UserBId == userId));

            if(matches.Count() > 1)
            {
                throw new Exception("A player should never be playing 2 matches at the same time!");
            }

            Match? match = null;
            Player? playerA = null;
            Player? playerB = null;
            string otherPlayerConnectionId = null;

            // Le joueur est dans un match en cours
            if (matches.Count() == 1)
            {
                match = matches.First();
                if(specificMatchId != null && specificMatchId != match.Id )
                {
                    match = null;
                }
                else
                {
                    playerA = _playersService.GetPlayerFromUserId(match.UserAId);
                    playerB = _playersService.GetPlayerFromUserId(match.UserBId);
                }
            }
            // Si on veut rejoindre un match en particulier, on ne se met pas en file
            else if(specificMatchId == null)
            {
                UsersReadyForAMatch? pairOfUsers = await _waitingUserService.LookForWaitingUser(userId, connectionId);

                if (pairOfUsers != null)
                {
                    playerA = _playersService.GetPlayerFromUserId(pairOfUsers.UserAId);
                    playerB = _playersService.GetPlayerFromUserId(pairOfUsers.UserBId);

                    var cardsA = await _decksService.GetMatchDeckCardsAsync(playerA.UserId);
                    var cardsB = await _decksService.GetMatchDeckCardsAsync(playerB.UserId);
                    match = new Match(playerA, playerB, cardsA, cardsB);
                    otherPlayerConnectionId = pairOfUsers.UserAConnectionId;

                    _dbContext.Update(match);
                    _dbContext.SaveChanges();
                }
            }

            if(match != null) {
                return new JoiningMatchData
                {
                    Match = match,
                    PlayerA = playerA!,
                    PlayerB = playerB!,
                    OtherPlayerConnectionId = otherPlayerConnectionId,
                    IsStarted = otherPlayerConnectionId == null
                };
            }

            return null;
        }

        public async Task<bool> StopJoiningMatch(string userId)
        {
            bool stoppedWaiting = await _waitingUserService.StopWaitingUser(userId);

            return stoppedWaiting;
        }

        // L'action retourne le json de l'event de création de match (StartMatchEvent)
        public async Task<StartMatchEvent> StartMatch(string currentUserId, Match match)
        {
            if ((match.UserAId == currentUserId) != match.IsPlayerATurn)
                throw new Exception("Ce n'est pas le tour de ce joueur");

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == currentUserId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            int nbCardsToDraw = _matchConfigurationService.GetNbCardsToDraw();
            int nbManaPerTurn = _matchConfigurationService.GetNbManaPerTurn();
            var startMatchEvent = new StartMatchEvent(match, currentPlayerData, opposingPlayerData, nbCardsToDraw, nbManaPerTurn);
            
            await _dbContext.SaveChangesAsync();

            return startMatchEvent;
        }

        public async Task<PlayerEndTurnEvent> EndTurn(string userId, int matchId)
        {
            var match = await GetMatchForGameplayAsync(matchId, userId);

            if ((match.UserAId == userId) != match.IsPlayerATurn)
                throw new InvalidOperationException("Ce n'est pas le tour de ce joueur");

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            int nbManaPerTurn = _matchConfigurationService.GetNbManaPerTurn();
            
            var playerEndTurnEvent = new PlayerEndTurnEvent(match, currentPlayerData, opposingPlayerData, nbManaPerTurn);

            await _dbContext.SaveChangesAsync();

            return playerEndTurnEvent;
        }

        public async Task<SurrenderEvent> Surrender(string userId, int matchId)
        {
            var match = await GetMatchForGameplayAsync(matchId, userId);

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;

            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            var surrenderEvent = new SurrenderEvent(
                match,
                currentPlayerData,
                opposingPlayerData,
                _matchConfigurationService.GetGoldWin(),
                _matchConfigurationService.GetGoldLoss());

            await _dbContext.SaveChangesAsync();

            return surrenderEvent;
        }


        public async Task<PlayCardEvent> PlayCard(string userId,int cardId, int matchId)
        {
            var match = await GetMatchForGameplayAsync(matchId, userId);

            if ((match.UserAId == userId) != match.IsPlayerATurn)
                throw new InvalidOperationException("Ce n'est pas le tour de ce joueur");

            MatchPlayerData currentPlayerData;
            MatchPlayerData opposingPlayerData;


            if (match.UserAId == userId)
            {
                currentPlayerData = match.PlayerDataA;
                opposingPlayerData = match.PlayerDataB;
            }
            else
            {
                currentPlayerData = match.PlayerDataB;
                opposingPlayerData = match.PlayerDataA;
            }

            var playCardEvent = new PlayCardEvent(match, currentPlayerData, cardId);

            await _dbContext.SaveChangesAsync();

            return playCardEvent;


        }

        private async Task<Match> GetMatchForGameplayAsync(int matchId, string userId)
        {
            var match = await _dbContext.Matches
                .Include(m => m.PlayerDataA).ThenInclude(p => p.Player)
                .Include(m => m.PlayerDataA).ThenInclude(p => p.BattleField).ThenInclude(c => c.Card)
                .Include(m => m.PlayerDataA).ThenInclude(p => p.Hand).ThenInclude(c => c.Card)
                .Include(m => m.PlayerDataA).ThenInclude(p => p.CardsPile).ThenInclude(c => c.Card)
                .Include(m => m.PlayerDataB).ThenInclude(p => p.Player)
                .Include(m => m.PlayerDataB).ThenInclude(p => p.BattleField).ThenInclude(c => c.Card)
                .Include(m => m.PlayerDataB).ThenInclude(p => p.Hand).ThenInclude(c => c.Card)
                .Include(m => m.PlayerDataB).ThenInclude(p => p.CardsPile).ThenInclude(c => c.Card)
                .FirstOrDefaultAsync(m => m.Id == matchId);

            if (match == null)
                throw new InvalidOperationException("Impossible de trouver le match");

            if (match.IsMatchCompleted)
                throw new InvalidOperationException("Le match est déjà terminé");

            if (match.UserAId != userId && match.UserBId != userId)
                throw new InvalidOperationException("Le joueur n'est pas dans ce match");

            return match;
        }
    }
}

