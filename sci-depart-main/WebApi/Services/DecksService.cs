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

            // Player player = await _dbContext.Players.FindAsync(userId);
            var player = await _dbContext.Players
                 .Include(p => p.Decks)
                 .ThenInclude(d => d.DeckCards)
                 .FirstOrDefaultAsync(p => p.UserId == userId);

            return player.Decks;
        }

      
        public async Task<IEnumerable<Deck>>CreateNewDeck(string userId, string nom)
        {
            //Recherche du joueur. On a besoin du joueur puisqu'on ajoute le nouveau deck à sa liste de Deck ensuite
            //Player player = await _dbContext.Players.FindAsync(userId);
            var player = await _dbContext.Players
              .Include(p => p.Decks)
              .ThenInclude(d => d.DeckCards)
              .FirstOrDefaultAsync(p => p.UserId == userId);


            List<DeckCards> deckCards = [];
            //Création du nouveau Deck avec le nom fourni en paramètres
            Deck newDeck = new Deck()
            {
                Name = nom,
                IsCurrent = false,
                DeckCards = deckCards
                

            };
           
            //Liste de DeckCards vide lors de la création
           
           

            player.Decks.Add(newDeck);
            _dbContext.Decks.Add(newDeck);
           await _dbContext.SaveChangesAsync();


            return player.Decks;
        }

        public async Task<IEnumerable<Deck>> DeleteDeckAsync(int deckId, string userId)
        {
            // Récupérer le joueur
            var player = await _dbContext.Players
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            // Récupérer le deck et vérifier qu'il appartient au joueur
            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");

            // Supprimer les cartes associées au deck
            _dbContext.DeckCards.RemoveRange(deck.DeckCards);

            // Supprimer le deck
            _dbContext.Decks.Remove(deck);

            // Sauvegarder les modifications
            await _dbContext.SaveChangesAsync();


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


        //public async Task<List<OwnedCards>> GetAvailableCardsForDeckAsync(int deckId, int playerId)
        //{

        //    Player player = await _dbContext.Players.FindAsync(playerId);

        //    // var deckCards = player.Decks
        //    var deckCards = await _dbContext.DeckCards
        //        .Where(dc => dc.Deck.Id == deckId)
        //        .Select(dc => dc.OwnedCard)
        //        .ToListAsync();

        //    var ownedCards = await _dbContext.OwnedCard
        //        .Where(oc => oc.player.Id == playerId)
        //        .ToListAsync();

        //    return ownedCards
        //        .Where(oc => !deckCards.Contains(oc) || oc.CardId > deckCards.Count(dc => dc == oc.id))
        //        .ToList();
        //}



        //public async Task<bool> CanAddCardToDeckAsync(int deckId, int playerId)
        //{

        //    Player player = await _dbContext.Players.FindAsync(playerId);

        //    var deck =  player.Decks
        //        .Where(d => d.Id == deckId ).FirstOrDefault();
        //    //Vérification : Si le nombre de decks du joueur est supérieur ou égal à maxDecks ou si le nombre de cartes du deck est supérieur ou égal à maxCardsPerDeck, on ne peut pas ajouter de carte

        //    if (deck == null || player.Decks.Count >= maxDecks || deck.DeckCards.Count >= maxCardsPerDeck  ) return false;
        //    //Devrait retourner vrai sinon
        //    return true;
        //}


        //Ajout d'une carte dans un deck
        //Remplacer int cardId pour que ca soit un OwnedCard id au lieu de Card
        public async Task<IEnumerable<Deck>> AddCardToDeckAsync(int deckId, int cardId, string userId)
        {
            // Récupérer le joueur
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            // Player player = await _dbContext.Players.FindAsync(userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            // Récupérer le deck
            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");

            // Vérifier si le deck a atteint la limite de cartes
            if (deck.DeckCards.Count >= maxCardsPerDeck)
                throw new InvalidOperationException("The deck has reached the maximum number of cards.");

            //Modification de la fonction : On véririe si le joueur peut ajouter une ou plusieurs cartes

          //  var ownedId = player.OwnedCards.FirstOrDefault(oc => oc.id == cardId);
            // Récupérer la carte possédée
            var ownedCard = player.OwnedCards.FirstOrDefault(oc => oc.CardId == cardId);
            if (ownedCard == null)
                throw new InvalidOperationException("Owned card not found or does not belong to the player.");

            // Vérifier si la carte est déjà dans le deck
            var cardCountInDeck = deck.DeckCards.Count(dc => dc.OwnedCard.id == ownedCard.id);
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


            //Version alternative
            //// Vérifier combien de copies de cette carte sont déjà dans le deck
            //var cardCountInDeck = deck.DeckCards.Count(dc => dc.OwnedCard.id == ownedCardId);

            //// Vérifier combien de copies de cette carte le joueur possède
            //var totalOwnedCopies = player.OwnedCards.Count(oc => oc.id == ownedCardId);

            //// Calculer combien de copies peuvent être ajoutées
            //var maxCopiesToAdd = totalOwnedCopies - cardCountInDeck;
            //if (maxCopiesToAdd <= 0)
            //    throw new InvalidOperationException("No more copies of this card can be added to the deck.");

            //// Limiter la quantité à ajouter à ce qui est possible
            //var actualQuantityToAdd = Math.Min(quantityToAdd, maxCopiesToAdd);

            //// Ajouter les copies au deck
            //for (int i = 0; i < actualQuantityToAdd; i++)
            //{
            //    var deckCard = new DeckCards
            //    {
            //        Deck = deck,
            //        OwnedCard = ownedCard
            //    };

            //    deck.DeckCards.Add(deckCard);
            //    _dbContext.DeckCards.Add(deckCard);
            //}

            // Sauvegarder les modifications
            await _dbContext.SaveChangesAsync();

            return player.Decks;
        }

        //Supprimer une carte d'un deck 
        public async Task<IEnumerable<Deck>> RemoveCardFromDeckAsync(int deckId, int cardId, string userId)
        {
            // Récupérer le joueur
            Player player = await _dbContext.Players.FindAsync(userId);


       //     Player player = await _dbContext.Players
       //.Include(p => p.Decks)
       //.ThenInclude(d => d.DeckCards)
       //.ThenInclude(dc => dc.OwnedCard)
       //.FirstOrDefaultAsync(p => p.UserId == userId);



            if (player == null)
                throw new InvalidOperationException("Player not found.");

            // Récupérer le deck
            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");
            var ownedCard = player.OwnedCards.FirstOrDefault(oc => oc.CardId == cardId);
            // Vérifier si la carte est dans le deck
            var deckCard = deck.DeckCards.FirstOrDefault(dc => dc.OwnedCard.id == ownedCard.id);
            if (deckCard == null)
                throw new InvalidOperationException("The card is not in the selected deck.");

            // Supprimer la carte du deck
            deck.DeckCards.Remove(deckCard);
            _dbContext.DeckCards.Remove(deckCard);

            // Sauvegarder les modifications
            await _dbContext.SaveChangesAsync();

            return player.Decks;
        }




    }
}
