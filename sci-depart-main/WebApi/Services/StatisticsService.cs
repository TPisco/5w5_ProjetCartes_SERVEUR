using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class StatisticsService
    {
        private readonly ApplicationDbContext _dbContext;

        public StatisticsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PlayerStatisticsDto> GetPlayerStatisticsAsync(string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.Decks)
                .FirstOrDefaultAsync(p => p.UserId == userId)
                ?? throw new InvalidOperationException("Joueur introuvable.");

            return new PlayerStatisticsDto
            {
                Wins = player.Wins,
                Losses = player.Losses,
                Gold = player.Gold,
                Decks = player.Decks.Select(d => new DeckStatisticsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Wins = d.Wins,
                    Losses = d.Losses,
                    IsCurrent = d.IsCurrent
                }).ToList()
            };
        }

        public async Task<CardDistributionDto> GetCardDistributionAsync(string userId, int? deckId = null)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards).ThenInclude(oc => oc.Card)
                .Include(p => p.Decks).ThenInclude(d => d.DeckCards).ThenInclude(dc => dc.OwnedCard).ThenInclude(oc => oc.Card)
                .FirstOrDefaultAsync(p => p.UserId == userId)
                ?? throw new InvalidOperationException("Joueur introuvable.");

            IEnumerable<Card> cards;

            if (deckId.HasValue)
            {
                var deck = player.Decks.FirstOrDefault(d => d.Id == deckId.Value)
                    ?? throw new InvalidOperationException("Deck introuvable.");
                cards = deck.DeckCards.Select(dc => dc.OwnedCard.Card);
            }
            else
            {
                cards = player.OwnedCards.Select(oc => oc.Card);
            }

            var cardList = cards.Where(c => c != null).ToList();

            return new CardDistributionDto
            {
                ByCost = GroupBy(cardList, c => c.Cost.ToString()),
                ByRarity = GroupBy(cardList, c => c.Rarity.ToString()),
                ByAttack = GroupBy(cardList, c => c.Attack.ToString()),
                ByHealth = GroupBy(cardList, c => c.Health.ToString())
            };
        }

        private static List<ChartDataPoint> GroupBy(IEnumerable<Card> cards, Func<Card, string> selector)
        {
            return cards
                .GroupBy(selector)
                .OrderBy(g => g.Key)
                .Select(g => new ChartDataPoint { Label = g.Key, Count = g.Count() })
                .ToList();
        }
    }
}
