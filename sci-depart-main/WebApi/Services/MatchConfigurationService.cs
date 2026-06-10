using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class MatchConfigurationService
    {
        private ApplicationDbContext _dbContext;

        public MatchConfigurationService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public int GetNbCardsToDraw() {
            // Stub: Pour l'intant, le stub retourne simplement 3
            // L'implémentation réelle devra la valeur configué
            // L'implémentation est la responsabilité de la personne en charge de la partie [Administration MVC]
            return _dbContext.GameConfigs.First().nbCardsToDraw;
        }

        public int GetNbManaPerTurn()
        {
            return _dbContext.GameConfigs.First().QtManaParTour;
        }

        public int GetGoldStarting() => _dbContext.GameConfigs.First().GoldStarting;
        public int GetGoldWin() => _dbContext.GameConfigs.First().GoldWin;
        public int GetGoldLoss() => _dbContext.GameConfigs.First().GoldLoss;
        public int GetMaxDecks() => _dbContext.GameConfigs.First().MaxDecks;
        public int GetMaxCardsPerDeck() => _dbContext.GameConfigs.First().MaxCardsPerDeck;
    }
}

