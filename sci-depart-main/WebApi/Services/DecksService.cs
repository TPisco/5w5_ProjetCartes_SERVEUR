using Microsoft.AspNetCore.Identity;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class DecksService
    {
        private ApplicationDbContext _dbContext;

        public DecksService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        
        public async Task<IEnumerable<Deck>> GetPlayerDecks(string userId)
        {
          
            Player player = await _dbContext.Players.FindAsync(userId);

            return player.Decks;
        }

      
        public async Task<IEnumerable<Deck>>CreateNewDeck(string userId, string nom)
        {
            //Recherche du joueur. On a besoin du joueur puisqu'on ajoute le nouveau deck à sa liste de Deck ensuite
            Player player = await _dbContext.Players.FindAsync(userId);


            //Création du nouveau Deck avec le nom fourni en paramètres
            Deck newDeck = new Deck();
            newDeck.Name = "Default";
            newDeck.IsCurrent = false;
            //Liste de DeckCards vide lors de la création
            List<DeckCards> deckCards = [];
            newDeck.DeckCards = deckCards;

            player.Decks.Add(newDeck);
            _dbContext.Decks.Add(newDeck);
            _dbContext.SaveChanges();


            return player.Decks;
        }

       
    }
}
