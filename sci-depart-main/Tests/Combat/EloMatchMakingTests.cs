using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Moq;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Hubs;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Services;
using WebApi.Services;

namespace Tests.Combat
{
    [TestClass]
    public class EloMatchMakingTests : BaseTests
    {
        public EloMatchMakingTests() { }
        [TestInitialize]
        public void Init()
        {
            base.Init();
        }

        [TestMethod]
        public void RetourDePairEloProche()
        {

            var hubContextMock = new Mock<IHubContext<MatchHub>>();
            var scopeFactoryMock = new Mock<IServiceScopeFactory>();
            var service = new MatchMakingBackGroundService(hubContextMock.Object, scopeFactoryMock.Object);



            var player1 = new PlayerInfo { UserId = "A", ELO = 1200, WaitTimeSeconds = 1 };
            var player2 = new PlayerInfo { UserId = "B", ELO = 1205, WaitTimeSeconds = 1 };

            var players = new List<PlayerInfo> { player1, player2 };

            var pairs = service.GeneratePairs(players);

            Assert.AreEqual(1, pairs.Count);
        }


        [TestMethod]
        public void RetourneVideSiELOsTropEloignesEtApresTempsLesMetEnsemble()
        {
            // SetUp
            var service = new MatchMakingBackGroundService(null!, null!);

            var player1 = new PlayerInfo { UserId = "A", ELO = 1000, WaitTimeSeconds = 1 };
            var player2 = new PlayerInfo { UserId = "B", ELO = 1400, WaitTimeSeconds = 1 };

            var players = new List<PlayerInfo> { player1, player2 };

            // Generation de pair
            var pairs = service.GeneratePairs(players);

            // Vérifier qu'il ny a pas de pair Créé
            Assert.AreEqual(0, pairs.Count);

            //on les fait attendre
            player1.WaitTimeSeconds = 100;
            player2.WaitTimeSeconds = 100;

            var players2 = new List<PlayerInfo> { player1, player2 };
            // Generation de pair
            var pairs2 = service.GeneratePairs(players2);

            // On vérifie si apres le temps passer il ont bien été mis ensemble malgré leur différence
            Assert.AreEqual(1, pairs2.Count);
        }





        [TestMethod]
        public void RetourneDeuxBonnesPairesSurSixJoueurs()
        {
            // Arrange
            var service = new MatchMakingBackGroundService(null!, null!);

            var players = new List<PlayerInfo>
            {
            new PlayerInfo { UserId = "A", ELO = 1000, WaitTimeSeconds = 1 },
            new PlayerInfo { UserId = "B", ELO = 1105, WaitTimeSeconds = 1 },
            new PlayerInfo { UserId = "C", ELO = 1100, WaitTimeSeconds = 1 },
            new PlayerInfo { UserId = "D", ELO = 1110, WaitTimeSeconds = 1 },
            new PlayerInfo { UserId = "E", ELO = 1115, WaitTimeSeconds = 1 },
            new PlayerInfo { UserId = "F", ELO = 1600, WaitTimeSeconds = 1 }, // Trop éloigné
            };

            // Act
            var pairs = service.GeneratePairs(players);

            // Assert
            Assert.AreEqual(2, pairs.Count);

            var pairUserIds = pairs.Select(p => new HashSet<string> { p.Player1.UserId, p.Player2.UserId }).ToList();

            Assert.IsTrue(pairUserIds.Any(set => set.SetEquals(new[] { "B", "C" })));
            Assert.IsTrue(pairUserIds.Any(set => set.SetEquals(new[] { "D", "E" })));
            Assert.IsFalse(pairUserIds.Any(set => set.Contains("A"))); // F ne doit pas être apparié
            Assert.IsFalse(pairUserIds.Any(set => set.Contains("F")));
        }

    }



}
