using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class PacksService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Random _random = new();

        public PacksService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pack>> GetAllPacksAsync()
        {
            return await _dbContext.Packs
                .Include(p => p.Probabilities)
                .ToListAsync();
        }

        public async Task<PackPurchaseResultDto> BuyPackAsync(string userId, int packId)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                .FirstOrDefaultAsync(p => p.UserId == userId)
                ?? throw new InvalidOperationException("Joueur introuvable.");

            var pack = await _dbContext.Packs
                .Include(p => p.Probabilities)
                .FirstOrDefaultAsync(p => p.Id == packId)
                ?? throw new InvalidOperationException("Paquet introuvable.");

            if (player.Gold < pack.Price)
                throw new InvalidOperationException("Pas assez de gold pour acheter ce paquet.");

            var rarities = GenerateRarities(pack);
            var drawnCards = new List<Card>();

            foreach (var rarity in rarities)
            {
                var candidates = await _dbContext.Cards
                    .Where(c => c.Rarity == rarity)
                    .ToListAsync();

                if (!candidates.Any())
                    throw new InvalidOperationException($"Aucune carte disponible pour la rareté {rarity}.");

                var card = candidates[_random.Next(candidates.Count)];
                drawnCards.Add(card);

                var owned = new OwnedCards
                {
                    player = player,
                    CardId = card.Id,
                    Card = card
                };
                player.OwnedCards.Add(owned);
                _dbContext.OwnedCard.Add(owned);
            }

            player.Gold -= pack.Price;
            await _dbContext.SaveChangesAsync();

            return new PackPurchaseResultDto
            {
                GoldRemaining = player.Gold,
                Cards = drawnCards
            };
        }

        public List<CardRarity> GenerateRarities(Pack pack)
        {
            var rarities = new List<CardRarity>();

            switch (pack.Id)
            {
                case 1: // Basic
                    rarities.AddRange(Enumerable.Repeat(pack.DefaultRarity, pack.CardCount));
                    for (int i = 0; i < rarities.Count; i++)
                    {
                        if (_random.NextDouble() < 0.30)
                            rarities[i] = CardRarity.Rare;
                    }
                    break;

                case 2: // Normal
                    rarities.Add(CardRarity.Rare);
                    while (rarities.Count < pack.CardCount)
                        rarities.Add(pack.DefaultRarity);

                    for (int i = 1; i < rarities.Count; i++)
                    {
                        rarities[i] = RollRarity(new Dictionary<CardRarity, double>
                        {
                            { CardRarity.Common, 58 },
                            { CardRarity.Rare, 30 },
                            { CardRarity.Epic, 10 },
                            { CardRarity.Legendary, 2 }
                        }, CardRarity.Common);
                    }
                    break;

                case 3: // Super
                    rarities.Add(CardRarity.Epic);
                    while (rarities.Count < pack.CardCount)
                        rarities.Add(pack.DefaultRarity);

                    for (int i = 1; i < rarities.Count; i++)
                    {
                        rarities[i] = RollRarity(new Dictionary<CardRarity, double>
                        {
                            { CardRarity.Rare, 65 },
                            { CardRarity.Epic, 25 },
                            { CardRarity.Legendary, 10 }
                        }, CardRarity.Rare);
                    }
                    break;

                default:
                    rarities.AddRange(Enumerable.Repeat(pack.DefaultRarity, pack.CardCount));
                    break;
            }

            return rarities;
        }

        private CardRarity RollRarity(Dictionary<CardRarity, double> probabilities, CardRarity fallback)
        {
            var roll = _random.NextDouble() * 100;
            double cumulative = 0;

            foreach (var entry in probabilities)
            {
                cumulative += entry.Value;
                if (roll <= cumulative)
                    return entry.Key;
            }

            return fallback;
        }
    }
}
