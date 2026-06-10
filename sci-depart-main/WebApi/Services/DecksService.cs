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
        private MatchConfigurationService _configService;

        public DecksService(ApplicationDbContext dbContext, MatchConfigurationService configService)
        {
            _dbContext = dbContext;
            _configService = configService;
        }

        public int maxDecks => _configService.GetMaxDecks();
        public int maxCardsPerDeck => _configService.GetMaxCardsPerDeck();

        
        public async Task<IEnumerable<Deck>> GetPlayerDecks(string userId)
        {

            // Player player = await _dbContext.Players.FindAsync(userId);
            var player = await _dbContext.Players
                 .Include(p => p.Decks)
                 .ThenInclude(d => d.DeckCards)
                 .ThenInclude(dc => dc.OwnedCard)
                 .ThenInclude(oc => oc.Card)
                 .FirstOrDefaultAsync(p => p.UserId == userId);

            return player?.Decks ?? Enumerable.Empty<Deck>();
        }

      
        public async Task<IEnumerable<Deck>>CreateNewDeck(string userId, string nom)
        {
            //Recherche du joueur. On a besoin du joueur puisqu'on ajoute le nouveau deck à sa liste de Deck ensuite
            //Player player = await _dbContext.Players.FindAsync(userId);
            var player = await _dbContext.Players
              .Include(p => p.Decks)
              .ThenInclude(d => d.DeckCards)
              .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            if (player.Decks.Count >= maxDecks)
                throw new InvalidOperationException("Nombre maximum de decks atteint.");

            //Création du nouveau Deck avec le nom fourni en paramètres
            Deck newDeck = new Deck();
            newDeck.Name = string.IsNullOrWhiteSpace(nom) ? "Deck" : nom;
            newDeck.IsCurrent = false;
            //Liste de DeckCards vide lors de la création
            List<DeckCards> deckCards = [];
            newDeck.DeckCards = deckCards;

            player.Decks.Add(newDeck);
            _dbContext.Decks.Add(newDeck);
            _dbContext.SaveChanges();


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

            if (deck.IsCurrent)
                throw new InvalidOperationException("Impossible de supprimer le deck courant.");

            // Supprimer les cartes associées au deck (DeckCards uniquement, pas les OwnedCards)
            _dbContext.DeckCards.RemoveRange(deck.DeckCards);

            // Supprimer le deck
            player.Decks.Remove(deck);
            _dbContext.Decks.Remove(deck);

            await _dbContext.SaveChangesAsync();

            return await GetPlayerDecks(userId);
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
        public async Task<IEnumerable<Deck>> AddCardToDeckAsync(int deckId, int cardId, string userId)
        {
            // Récupérer le joueur
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .ThenInclude(dc => dc.OwnedCard)
                .ThenInclude(oc => oc.Card)
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

            // Récupérer une copie possédée disponible pour ce deck
            var ownedCount = player.OwnedCards.Count(oc => oc.CardId == cardId);
            var inDeckCount = deck.DeckCards.Count(dc => dc.OwnedCard.CardId == cardId);
            if (inDeckCount >= ownedCount)
                throw new InvalidOperationException("Aucune copie disponible de cette carte pour ce deck.");

            var ownedCard = player.OwnedCards
                .FirstOrDefault(oc => oc.CardId == cardId && !deck.DeckCards.Any(dc => dc.OwnedCard.id == oc.id));
            if (ownedCard == null)
                throw new InvalidOperationException("Owned card not found or does not belong to the player.");

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

        public async Task<IEnumerable<Deck>> SetCurrentDeckAsync(int deckId, string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");

            foreach (var d in player.Decks)
                d.IsCurrent = d.Id == deckId;

            await _dbContext.SaveChangesAsync();
            return await GetPlayerDecks(userId);
        }

        public async Task<IEnumerable<Card>> GetMatchDeckCardsAsync(string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                    .ThenInclude(oc => oc.Card)
                        .ThenInclude(c => c.CardPowers)
                            .ThenInclude(cp => cp.Power)
                .Include(p => p.Decks)
                    .ThenInclude(d => d.DeckCards)
                        .ThenInclude(dc => dc.OwnedCard)
                            .ThenInclude(oc => oc.Card)
                                .ThenInclude(c => c.CardPowers)
                                    .ThenInclude(cp => cp.Power)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            var currentDeck = player.Decks.FirstOrDefault(d => d.IsCurrent) ?? player.Decks.FirstOrDefault();
            if (currentDeck == null || !currentDeck.DeckCards.Any())
            {
                return player.OwnedCards
                    .Select(oc => oc.Card)
                    .Where(c => c != null)
                    .ToList();
            }

            return currentDeck.DeckCards
                .Select(dc => dc.OwnedCard.Card)
                .Where(c => c != null)
                .ToList();
        }

        public async Task<IEnumerable<Deck>> CreateDeckWithCardsAsync(string userId, string nom, IEnumerable<int> cardIds)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new InvalidOperationException("Le nom du deck est requis.");

            var ids = cardIds?.ToList() ?? new List<int>();
            if (ids.Count > maxCardsPerDeck)
                throw new InvalidOperationException($"Un deck ne peut pas contenir plus de {maxCardsPerDeck} cartes.");

            await CreateNewDeck(userId, nom);

            var player = await _dbContext.Players
                .Include(p => p.Decks)
                .FirstOrDefaultAsync(p => p.UserId == userId)
                ?? throw new InvalidOperationException("Player not found.");

            var deck = player.Decks.OrderByDescending(d => d.Id).First();

            foreach (var cardId in ids)
            {
                await AddCardToDeckAsync(deck.Id, cardId, userId);
            }

            return await GetPlayerDecks(userId);
        }

        public async Task<IEnumerable<Card>> GetAvailableCardsForDeckAsync(int deckId, string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards).ThenInclude(oc => oc.Card)
                .Include(p => p.Decks).ThenInclude(d => d.DeckCards).ThenInclude(dc => dc.OwnedCard)
                .FirstOrDefaultAsync(p => p.UserId == userId)
                ?? throw new InvalidOperationException("Player not found.");

            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId)
                ?? throw new InvalidOperationException("Deck not found or does not belong to the player.");

            return player.OwnedCards
                .Where(oc =>
                {
                    var inDeck = deck.DeckCards.Count(dc => dc.OwnedCard.CardId == oc.CardId);
                    var owned = player.OwnedCards.Count(o => o.CardId == oc.CardId);
                    return inDeck < owned;
                })
                .Select(oc => oc.Card)
                .GroupBy(c => c.Id)
                .Select(g => g.First())
                .OrderBy(c => c.Name)
                .ToList();
        }

        public object GetDeckLimits() => new { maxDecks, maxCardsPerDeck };

        //Supprimer une carte d'un deck 
        public async Task<IEnumerable<Deck>> RemoveCardFromDeckAsync(int deckId, int cardId, string userId)
        {
            var player = await _dbContext.Players
                .Include(p => p.OwnedCards)
                .Include(p => p.Decks)
                .ThenInclude(d => d.DeckCards)
                .ThenInclude(dc => dc.OwnedCard)
                .ThenInclude(oc => oc.Card)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (player == null)
                throw new InvalidOperationException("Player not found.");

            var deck = player.Decks.FirstOrDefault(d => d.Id == deckId);
            if (deck == null)
                throw new InvalidOperationException("Deck not found or does not belong to the player.");

            var deckCard = deck.DeckCards.FirstOrDefault(dc => dc.OwnedCard.CardId == cardId);
            if (deckCard == null)
                throw new InvalidOperationException("The card is not in the selected deck.");

            deck.DeckCards.Remove(deckCard);
            _dbContext.DeckCards.Remove(deckCard);
            await _dbContext.SaveChangesAsync();

            return player.Decks;
        }




    }
}
