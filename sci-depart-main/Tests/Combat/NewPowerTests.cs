using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Services;

namespace Tests.Combat
{
    [TestClass]
    public class NewPowerTests : BaseTests
    {
        [TestInitialize]
        public void Init()
        {
            base.Init();
        }

        [TestMethod]
        public void Chaos_InverseAttackAndDefense()
        {
            _cardA.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                        Card = _cardA,
                        PowerId = Power.CHAOS_ID,
                        Power = new Power 
                        {
                            Id = Power.CHAOS_ID,
                        }
                }
            };
            _playableCardA.Attack = 5;
            _playableCardA.Health = 8;

            _playableCardB.Attack = 10;
            _playableCardB.Health = 5;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(8, _playableCardA.Attack);
            Assert.AreEqual(5, _playableCardA.Health);

            Assert.AreEqual(5, _playableCardB.Attack);
            Assert.AreEqual(10, _playableCardB.Health);
            AssertBothCardsStillOnBattlefield();
        }

        [TestMethod]
        public void Chaos_KillsCardWhenAttackEqualZero()
        {
            _cardB.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                    Card = _cardB,
                    PowerId = Power.CHAOS_ID,
                    Power = new Power
                    { 
                        Id = Power.CHAOS_ID 
                    }
                }
            };
            _playableCardA.Attack = 0;
            _playableCardA.Health = 4;

            _playableCardB.Attack = 3;
            _playableCardB.Health = 2;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(0, _playableCardA.Health);
            AssertCurrentPlayerCardDied();
        }

        [TestMethod]
        public void Poison_AddsValueToAttackedCard()
        {
            _cardA.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                    Card = _cardA,
                    PowerId = Power.POISON_ID,
                    Power = new Power 
                    { 
                        Id = Power.POISON_ID, 
                        HasValue = true 
                    },
                    Value = 1
                }
            };
            _playableCardB.Health = _cardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            int PoisonValue = 1;
            int expectedResult = _cardB.Health - _cardA.Attack - PoisonValue;
            Assert.AreEqual(expectedResult, _playableCardB.Health);
        }

        [TestMethod]
        public void Poison_StacksValues()
        {
            _cardA.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                    Card = _cardA,
                    PowerId = Power.POISON_ID,
                    Power = new Power 
                    { 
                        Id = Power.POISON_ID, 
                        HasValue = true 
                    },
                    Value = 2
                }
            };
            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            _currentPlayerData.BattleField.Clear(); 

            _opposingPlayerData.BattleField.Clear();

            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            int totalPoison = _playableCardB.Card.CardPowers.Find(cp => cp.PowerId == Power.POISON_ID).Value;
            Assert.AreEqual(4, totalPoison);
        }

        [TestMethod]
        public void Shield_AddHealthToCard()
        {
            _cardA.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                    Card = _cardA,
                    PowerId = Power.SHIELD_ID,
                    Power = new Power
                    {
                        Id = Power.SHIELD_ID,
                        HasValue = true
                    },
                    Value = 2
                }
            };
            _playableCardB.Health = _cardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            int ShieldValue = 2;
            int expectedResult = _playableCardB.Health + ShieldValue;
            Assert.AreEqual(expectedResult, _playableCardB.Health);
        }

        [TestMethod]
        public void Shield_AddedHealthStacks()
        {
            _cardA.CardPowers = new List<CardPower>
            {
                new CardPower
                {
                    Card = _cardA,
                    PowerId = Power.SHIELD_ID,
                    Power = new Power
                    {
                        Id = Power.SHIELD_ID,
                        HasValue = true
                    },
                    Value = 2
                }
            };
            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            _currentPlayerData.BattleField.Clear();

            _opposingPlayerData.BattleField.Clear();

            _currentPlayerData.BattleField.Add(_playableCardA);

            _opposingPlayerData.BattleField.Add(_playableCardB);

            new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            int totalShield = _playableCardB.Card.CardPowers.Find(cp => cp.PowerId == Power.SHIELD_ID).Value;
            Assert.AreEqual(4, totalShield);
        }
    }
}
