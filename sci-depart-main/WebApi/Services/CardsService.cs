using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Card> GetPlayersCards(string userId)
        {
            // Stub: Pour l'intant, le stub retourne simplement les 8 premières cartes
            // L'implémentation réelle devra utiliser un service et retourner les cartes qu'un joueur possède
            // L'implémentation est la responsabilité de la personne en charge de la partie [Enregistrement et connexion]
            return _dbContext.Cards.Take(8).ToList();
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }

        public async Task<Card?> CreateCard(string name,int manaCost, int health, int Attaque, string imageURL)
        {
            if (_dbContext == null) return null;

            Card newCard = new Card()
            {
                Name = name,
                Cost = manaCost,
                Health = health,
                Attack = Attaque,
                ImageUrl = imageURL
            };
            _dbContext.Cards.Add(newCard);
            await _dbContext.SaveChangesAsync();
            return newCard;
        }

        public async Task<Card?> EditCard(int cardId, string name, int manaCost, int health, int attack, string imageURL)
        {
            var card = await _dbContext.Cards.FindAsync(cardId);
            if (card == null)
                return null;

            card.Name = name;
            card.Cost = manaCost;
            card.Health = health;
            card.Attack = attack;
            card.ImageUrl = imageURL;

            await _dbContext.SaveChangesAsync();
            return card;
        }

        public async Task<bool> DeleteCard(int cardId)
        {
            var card = await _dbContext.Cards.FindAsync(cardId);
            if (card == null)
                return false;

            _dbContext.Cards.Remove(card);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
