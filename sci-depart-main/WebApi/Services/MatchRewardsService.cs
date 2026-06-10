using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class MatchRewardsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly MatchConfigurationService _configService;

        public MatchRewardsService(ApplicationDbContext dbContext, MatchConfigurationService configService)
        {
            _dbContext = dbContext;
            _configService = configService;
        }

        public async Task ApplyMatchEndRewardsAsync(int matchId, int winningPlayerId)
        {
            var match = await _dbContext.Matches
                .Include(m => m.PlayerDataA).ThenInclude(pd => pd.Player).ThenInclude(p => p.Decks)
                .Include(m => m.PlayerDataB).ThenInclude(pd => pd.Player).ThenInclude(p => p.Decks)
                .FirstOrDefaultAsync(m => m.Id == matchId);

            if (match?.IsMatchCompleted != true || match.RewardsApplied)
                return;

            var winnerData = match.PlayerDataA.PlayerId == winningPlayerId ? match.PlayerDataA : match.PlayerDataB;
            var loserData = match.PlayerDataA.PlayerId == winningPlayerId ? match.PlayerDataB : match.PlayerDataA;

            if (winnerData?.Player == null || loserData?.Player == null)
                return;

            var goldWin = _configService.GetGoldWin();
            var goldLoss = _configService.GetGoldLoss();

            winnerData.Player.Wins++;
            loserData.Player.Losses++;
            winnerData.Player.Gold += goldWin;
            loserData.Player.Gold += goldLoss;

            UpdateDeckStats(winnerData.Player, true);
            UpdateDeckStats(loserData.Player, false);

            match.RewardsApplied = true;
            await _dbContext.SaveChangesAsync();
        }

        private static void UpdateDeckStats(Player player, bool isWin)
        {
            var currentDeck = player.Decks?.FirstOrDefault(d => d.IsCurrent);
            if (currentDeck == null)
                return;

            if (isWin)
                currentDeck.Wins++;
            else
                currentDeck.Losses++;
        }
    }
}
