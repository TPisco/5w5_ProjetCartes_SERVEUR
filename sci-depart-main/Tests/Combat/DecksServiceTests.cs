using Microsoft.EntityFrameworkCore;
using Moq;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Services;
using Models.Models;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Super_Cartes_Infinies.Models;
using Tests.Services;

[TestClass]
public class DecksServiceTests : BaseTests
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DecksService _decksService;

    public DecksServiceTests()
    {
        // Configurer une base de données en mémoire
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _dbContext = new ApplicationDbContext(options);
        _decksService = new DecksService(_dbContext);
    }

    [TestInitialize]
    public void Init()
    {
        base.Init();
    }

    [TestMethod]
    public async Task CreateNewDeck_ShouldCreateDeck()
    {
        // Arrange
        var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>() };
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _decksService.CreateNewDeck("user1", "My New Deck");

        // Assert
        //Assert.Single(result);
        Assert.AreEqual("Default", result.First().Name);
    }

    //[TestMethod]
    //public async Task DeleteDeckAsync_ShouldDeleteDeck()
    //{
    //    // Arrange
    //    var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>() };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    player.Decks.Add(deck);
    //    _dbContext.Players.Add(player);
    //    await _dbContext.SaveChangesAsync();

    //    // Act
    //    var result = await _decksService.DeleteDeckAsync(1, "user1");

    //    // Assert
    //    Assert.Empty(result);
    //    Assert.Empty(_dbContext.Decks);
    //}

    //[TestMethod]
    //public async Task DeleteDeckAsync_ShouldThrowIfDeckNotOwnedByPlayer()
    //{
    //    // Arrange
    //    var player = new Player { Id = 1, UserId = "user1", Decks = new List<Deck>() };
    //    var otherPlayer = new Player { Id = 2, UserId = "user2", Decks = new List<Deck>() };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    otherPlayer.Decks.Add(deck);
    //    _dbContext.Players.Add(player);
    //    _dbContext.Players.Add(otherPlayer);
    //    await _dbContext.SaveChangesAsync();

    //    // Act & Assert
    //    await Assert.ThrowsAsync<InvalidOperationException>(() => _decksService.DeleteDeckAsync(1, "user1"));
    //}

    //[TestMethod]
    //public async Task AddCardToDeckAsync_ShouldAddCardToDeck()
    //{
    //    // Arrange
    //    var player = new Player
    //    {
    //        Id = 1,
    //        UserId = "user1",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    var card = new OwnedCards { id = 1, CardId = 1, player = player };
    //    player.Decks.Add(deck);
    //    player.OwnedCards.Add(card);
    //    _dbContext.Players.Add(player);
    //    await _dbContext.SaveChangesAsync();

    //    // Act
    //    var result = await _decksService.AddCardToDeckAsync(1, 1, "user1");

    //    // Assert
    //    Assert.Single(deck.DeckCards);
    //    Assert.Equal(1, deck.DeckCards.First().OwnedCard.id);
    //}

    //[TestMethod]
    //public async Task AddCardToDeckAsync_ShouldThrowIfDeckOrCardNotOwnedByPlayer()
    //{
    //    // Arrange
    //    var player = new Player
    //    {
    //        Id = 1,
    //        UserId = "user1",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var otherPlayer = new Player
    //    {
    //        Id = 2,
    //        UserId = "user2",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    var card = new OwnedCards { id = 1, CardId = 1, player = otherPlayer };
    //    otherPlayer.Decks.Add(deck);
    //    otherPlayer.OwnedCards.Add(card);
    //    _dbContext.Players.Add(player);
    //    _dbContext.Players.Add(otherPlayer);
    //    await _dbContext.SaveChangesAsync();

    //    // Act & Assert
    //    await Assert.ThrowsAsync<InvalidOperationException>(() => _decksService.AddCardToDeckAsync(1, 1, "user1"));
    //}

    //[TestMethod]
    //public async Task RemoveCardFromDeckAsync_ShouldRemoveCardFromDeck()
    //{
    //    // Arrange
    //    var player = new Player
    //    {
    //        Id = 1,
    //        UserId = "user1",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    var card = new OwnedCards { id = 1, CardId = 1, player = player };
    //    var deckCard = new DeckCards { Id = 1, Deck = deck, OwnedCard = card };
    //    deck.DeckCards.Add(deckCard);
    //    player.Decks.Add(deck);
    //    player.OwnedCards.Add(card);
    //    _dbContext.Players.Add(player);
    //    await _dbContext.SaveChangesAsync();

    //    // Act
    //    var result = await _decksService.RemoveCardFromDeckAsync(1, 1, "user1");

    //    // Assert
    //    Assert.Empty(deck.DeckCards);
    //}
    //[TestMethod]
    //public async Task RemoveCardFromDeckAsync_ShouldThrowIfDeckNotOwnedByPlayer()
    //{
    //    // Arrange
    //    var player = new Player
    //    {
    //        Id = 1,
    //        UserId = "user1",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var otherPlayer = new Player
    //    {
    //        Id = 2,
    //        UserId = "user2",
    //        Decks = new List<Deck>(),
    //        OwnedCards = new List<OwnedCards>()
    //    };
    //    var deck = new Deck { Id = 1, Name = "Test Deck", DeckCards = new List<DeckCards>() };
    //    var card = new OwnedCards { id = 1, CardId = 1, player = otherPlayer };
    //    var deckCard = new DeckCards { Id = 1, Deck = deck, OwnedCard = card };
    //    deck.DeckCards.Add(deckCard);
    //    otherPlayer.Decks.Add(deck);
    //    otherPlayer.OwnedCards.Add(card);
    //    _dbContext.Players.Add(player);
    //    _dbContext.Players.Add(otherPlayer);
    //    await _dbContext.SaveChangesAsync();

    //    // Act & Assert
    //    await Assert.ThrowsAsync<InvalidOperationException>(() => _decksService.RemoveCardFromDeckAsync(1, 1, "user1"));
    //}
}
