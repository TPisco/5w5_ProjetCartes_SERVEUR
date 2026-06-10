using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Tests.Services
{
[TestClass]
public class DecksServiceTests
{
    private ApplicationDbContext _dbContext = null!;
    private DecksService _decksService = null!;

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new ApplicationDbContext(options);
        _dbContext.GameConfigs.Add(new GameConfig
        {
            id = 1,
            QtManaParTour = 3,
            nbCardsToDraw = 4,
            GoldStarting = 300,
            GoldWin = 20,
            GoldLoss = 5,
            MaxDecks = 10,
            MaxCardsPerDeck = 30
        });
        _dbContext.SaveChanges();

        _decksService = new DecksService(_dbContext, new MatchConfigurationService(_dbContext));
    }

    [TestMethod]
    public async Task CreateNewDeck_ShouldCreateDeck()
    {
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        var result = (await _decksService.CreateNewDeck("user1", "Mon Deck")).ToList();

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Mon Deck", result[0].Name);
    }

    [TestMethod]
    public async Task DeleteDeckAsync_ShouldDeleteDeck()
    {
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        player.Decks.Add(deck);
        _dbContext.Players.Add(player);
        _dbContext.Decks.Add(deck);
        await _dbContext.SaveChangesAsync();

        var result = (await _decksService.DeleteDeckAsync(1, "user1")).ToList();

        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public async Task DeleteDeckAsync_ShouldThrowIfDeckNotOwnedByPlayer()
    {
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var otherPlayer = new Player { Id = 2, UserId = "user2", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        otherPlayer.Decks.Add(deck);
        _dbContext.Players.AddRange(player, otherPlayer);
        _dbContext.Decks.Add(deck);
        await _dbContext.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _decksService.DeleteDeckAsync(1, "user1"));
    }

    [TestMethod]
    public async Task AddCardToDeckAsync_ShouldAddCardToDeck()
    {
        var card = new Card { Id = 1, Name = "Test", Attack = 1, Health = 1, Cost = 1 };
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        var owned = new OwnedCards { id = 1, CardId = 1, Card = card, player = player };
        player.Decks.Add(deck);
        player.OwnedCards.Add(owned);
        _dbContext.Cards.Add(card);
        _dbContext.Players.Add(player);
        _dbContext.Decks.Add(deck);
        _dbContext.OwnedCard.Add(owned);
        await _dbContext.SaveChangesAsync();

        await _decksService.AddCardToDeckAsync(1, 1, "user1");

        Assert.AreEqual(1, deck.DeckCards.Count);
    }

    [TestMethod]
    public async Task AddCardToDeckAsync_ShouldThrowIfDeckOrCardNotOwnedByPlayer()
    {
        var card = new Card { Id = 1, Name = "Test", Attack = 1, Health = 1, Cost = 1 };
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var otherPlayer = new Player { Id = 2, UserId = "user2", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        var owned = new OwnedCards { id = 1, CardId = 1, Card = card, player = otherPlayer };
        otherPlayer.Decks.Add(deck);
        otherPlayer.OwnedCards.Add(owned);
        _dbContext.Cards.Add(card);
        _dbContext.Players.AddRange(player, otherPlayer);
        _dbContext.Decks.Add(deck);
        _dbContext.OwnedCard.Add(owned);
        await _dbContext.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _decksService.AddCardToDeckAsync(1, 1, "user1"));
    }

    [TestMethod]
    public async Task RemoveCardFromDeckAsync_ShouldRemoveCardFromDeck()
    {
        var card = new Card { Id = 1, Name = "Test", Attack = 1, Health = 1, Cost = 1 };
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        var owned = new OwnedCards { id = 1, CardId = 1, Card = card, player = player };
        var deckCard = new DeckCards { Id = 1, Deck = deck, OwnedCard = owned };
        deck.DeckCards.Add(deckCard);
        player.Decks.Add(deck);
        player.OwnedCards.Add(owned);
        _dbContext.Cards.Add(card);
        _dbContext.Players.Add(player);
        _dbContext.Decks.Add(deck);
        _dbContext.DeckCards.Add(deckCard);
        _dbContext.OwnedCard.Add(owned);
        await _dbContext.SaveChangesAsync();

        await _decksService.RemoveCardFromDeckAsync(1, 1, "user1");

        Assert.AreEqual(0, deck.DeckCards.Count);
    }

    [TestMethod]
    public async Task RemoveCardFromDeckAsync_ShouldThrowIfDeckNotOwnedByPlayer()
    {
        var card = new Card { Id = 1, Name = "Test", Attack = 1, Health = 1, Cost = 1 };
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var otherPlayer = new Player { Id = 2, UserId = "user2", Decks = new List<Deck>(), OwnedCards = new List<OwnedCards>() };
        var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
        var owned = new OwnedCards { id = 1, CardId = 1, Card = card, player = otherPlayer };
        var deckCard = new DeckCards { Id = 1, Deck = deck, OwnedCard = owned };
        deck.DeckCards.Add(deckCard);
        otherPlayer.Decks.Add(deck);
        _dbContext.Cards.Add(card);
        _dbContext.Players.Add(player);
        _dbContext.Players.Add(otherPlayer);
        _dbContext.Decks.Add(deck);
        _dbContext.DeckCards.Add(deckCard);
        await _dbContext.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _decksService.RemoveCardFromDeckAsync(1, 1, "user1"));
    }
}
}
