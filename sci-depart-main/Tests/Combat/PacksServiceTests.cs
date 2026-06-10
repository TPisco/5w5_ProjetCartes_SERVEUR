using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Tests.Services
{
[TestClass]
public class PacksServiceTests
{
    private ApplicationDbContext _dbContext = null!;
    private PacksService _packsService = null!;

    [TestInitialize]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new ApplicationDbContext(options);

        _dbContext.Cards.AddRange(
            Enumerable.Range(1, 8).Select(i => new Card
            {
                Id = i,
                Name = $"Card{i}",
                Attack = i,
                Health = i,
                Cost = i % 5 + 1,
                Rarity = i <= 2 ? CardRarity.Common : i <= 4 ? CardRarity.Rare : i <= 6 ? CardRarity.Epic : CardRarity.Legendary
            })
        );

        _dbContext.Packs.AddRange(
            new Pack { Id = 1, Name = "Basic", Price = 50, CardCount = 3, DefaultRarity = CardRarity.Common },
            new Pack { Id = 2, Name = "Normal", Price = 100, CardCount = 4, DefaultRarity = CardRarity.Common },
            new Pack { Id = 3, Name = "Super", Price = 200, CardCount = 5, DefaultRarity = CardRarity.Rare }
        );

        _dbContext.SaveChanges();
        _packsService = new PacksService(_dbContext);
    }

    [TestMethod]
    public async Task BuyPack_ShouldGiveCorrectCardCountAndDebitGold()
    {
        var player = new Player { Id = 1, UserId = "user1", Gold = 500, OwnedCards = new List<OwnedCards>() };
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        var result = await _packsService.BuyPackAsync("user1", 1);

        Assert.AreEqual(3, result.Cards.Count);
        Assert.AreEqual(450, result.GoldRemaining);
        Assert.AreEqual(450, player.Gold);
    }

    [TestMethod]
    public async Task BuyPack_ShouldFailWithoutEnoughGold()
    {
        var player = new Player { Id = 1, UserId = "user1", Gold = 10, OwnedCards = new List<OwnedCards>() };
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _packsService.BuyPackAsync("user1", 2));
    }

    [TestMethod]
    public void SuperPack_ShouldNotContainCommonCardsAndMustContainEpic()
    {
        var pack = _dbContext.Packs.First(p => p.Id == 3);
        var rarities = _packsService.GenerateRarities(pack);

        Assert.AreEqual(5, rarities.Count);
        CollectionAssert.DoesNotContain(rarities, CardRarity.Common);
        Assert.IsTrue(rarities.Contains(CardRarity.Epic));
    }
}
}
