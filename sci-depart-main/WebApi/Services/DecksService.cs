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

        //public async Task<List<Card>> GetAvailableCardsForDeckAsync(int deckId, string userId)
        //{

        //    Player player = await _dbContext.Players.FindAsync(userId);

        //    var deckCards = await _dbContext.DeckCards
        //        .Where(dc => dc.DeckId == deckId)
        //        .Select(dc => dc.CardId)
        //        .ToListAsync();

        //    var ownedCards = await _dbContext.OwnedCards
        //        .Where(oc => oc.PlayerId == playerId)
        //        .ToListAsync();

        //    return ownedCards
        //        .Where(oc => !deckCards.Contains(oc.CardId) || oc.Quantity > deckCards.Count(dc => dc == oc.CardId))
        //        .Select(oc => oc.Card)
        //        .ToList();
        //}


        public async Task<List<OwnedCards>> GetAvailableCardsForDeckAsync(int deckId, int playerId)
        {
            var deckCards = await _dbContext.DeckCards
                .Where(dc => dc.Deck.Id == deckId)
                .Select(dc => dc.OwnedCard.Id)
                .ToListAsync();

            var ownedCards = await _dbContext.OwnedCards
                .Where(oc => oc.player.Id == playerId)
                .ToListAsync();

            return ownedCards
                .Where(oc => !deckCards.Contains(oc.id) || oc.CardId > deckCards.Count(dc => dc == oc.id))
                .ToList();
        }





    }
}
