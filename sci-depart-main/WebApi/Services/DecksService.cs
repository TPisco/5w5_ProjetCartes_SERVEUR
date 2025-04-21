using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class DecksService
    {
        private ApplicationDbContext _dbContext;
        public int maxDecks = 10;
        public int maxCardsPerDeck = 30;

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

            Player player = await _dbContext.Players.FindAsync(playerId);

           // var deckCards = player.Decks
            //var deckCards = await _dbContext.DeckCards
            //    .Where(dc => dc.Deck.Id == deckId)
            //    .Select(dc => dc.OwnedCard.Id)
            //    .ToListAsync();

            //var ownedCards = await _dbContext.OwnedCards
            //    .Where(oc => oc.player.Id == playerId)
            //    .ToListAsync();

            //return ownedCards
            //    .Where(oc => !deckCards.Contains(oc.id) || oc.CardId > deckCards.Count(dc => dc == oc.id))
            //    .ToList();
        }



        public async Task<bool> CanAddCardToDeckAsync(int deckId, int playerId)
        {

            Player player = await _dbContext.Players.FindAsync(playerId);

            var deck =  player.Decks
                .Where(d => d.Id == deckId ).FirstOrDefault();
            //Vérification : Si le nombre de decks du joueur est supérieur ou égal à maxDecks ou si le nombre de cartes du deck est supérieur ou égal à maxCardsPerDeck, on ne peut pas ajouter de carte

            if (deck == null || player.Decks.Count >= maxDecks || deck.DeckCards.Count >= maxCardsPerDeck  ) return false;
            //Devrait retourner vrai sinon
            return true;
        }


        //Ajout d'une carte dans un deck
        public async Task<IEnumerable<Deck>> AddCardToDeckAsync(int deckId, int ownedCardId, int playerId)
        {
            // Récupérer le joueur
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .FirstOrDefaultAsync(p => p.Id == playerId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            // Récupérer le deck
            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");

            // Vérifier si le deck a atteint la limite de cartes
            if (deck.DeckCards.Count >= maxCardsPerDeck)
                throw new InvalidOperationException("The deck has reached the maximum number of cards.");

            // Récupérer la carte possédée
            var ownedCard = player.OwnedCards.FirstOrDefault(oc => oc.id == ownedCardId);
            if (ownedCard == null)
                throw new InvalidOperationException("Owned card not found or does not belong to the player.");

            // Vérifier si la carte est déjà dans le deck
            var cardCountInDeck = deck.DeckCards.Count(dc => dc.OwnedCard.id == ownedCardId);
            if (cardCountInDeck >= 1) // Une seule copie d'une carte possédée peut être ajoutée
                throw new InvalidOperationException("This card is already in the deck.");

            // Ajouter la carte au deck
            var deckCard = new DeckCards
            {
                Deck = deck,
                OwnedCard = ownedCard
            };

            deck.DeckCards.Add(deckCard);
            _dbContext.DeckCards.Add(deckCard);

            // Sauvegarder les modifications
            await _dbContext.SaveChangesAsync();

            return player.Decks;
        }



    }
}
