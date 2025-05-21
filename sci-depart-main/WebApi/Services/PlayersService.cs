using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using System.Numerics;

namespace Super_Cartes_Infinies.Services
{
	public class PlayersService
    {
        private ApplicationDbContext _dbContext;
        private StartingCardsService _startingCardsService;

        public PlayersService(ApplicationDbContext context, StartingCardsService startingCardsService)
        {
            _dbContext = context;
            _startingCardsService = startingCardsService;
        }

        public Player CreatePlayer(IdentityUser user)
        {
            Player p = new Player()
            {
                Id = 0,
                UserId = user.Id,
                Name = user.Email!
            };


            // TODO: Utilisez le service StartingCardsService pour obtenir les cartes de départ
            var StartingCards = _startingCardsService.GetStartingCards();

            //Ajout de la logique pour créer un deck initial
            p.Decks = new List<Deck>();

            Deck startingDeck = new Deck();



            startingDeck.Name = "Default";
            startingDeck.IsCurrent = true;
            startingDeck.DeckCards = new List<DeckCards>();
            // TODO: Ajoutez ces cartes au joueur en utilisant le modèle OwnedCard que vous allez devoir ajouter
            foreach (var OwnedCard in StartingCards)
            {
                DeckCards deckCards = new DeckCards();
                var ownedCards = new OwnedCards()
                {
                    player = p,
                    Card = OwnedCard,
                };
                //Ajout des données pour DeckCards
                deckCards.Deck = startingDeck;
                deckCards.OwnedCard = ownedCards;
                startingDeck.DeckCards.Add(deckCards);

                _dbContext.OwnedCard.Add(ownedCards);
            }

            //Création du Deck initial

      

            p.Decks.Add(startingDeck);

            _dbContext.Players.Add(p);
            //Ajout du deck dans la database
            _dbContext.Decks.Add(startingDeck);
            _dbContext.SaveChanges();

            return p;
        }

        public virtual Player GetPlayerFromUserId(string userId)
        {
            return _dbContext.Players.Single(p => p.UserId == userId);
        }

        public Player GetPlayerFromUserName(string userName)
        {
            return _dbContext.Players.Single(p => p.User!.UserName == userName);
        }

       
    }
}

