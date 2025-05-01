using Models.Migrations;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Tests.Services;
using Status = Models.Models.Status;

namespace Tests.Combat
{
    [TestClass]
    public class StatusTests : BaseTests
    {
        public StatusTests()
        {
           
        }

        [TestInitialize]
        public void Init()
        {
            base.Init();
        }




        //TODO 1 : Ajouter des tests pour le ApplyPoison Event (Vérifier l'ajout du staus)

        //Test pour ajouter un nouveau status Poison à une carte
        [TestMethod]
        public void ApplyPoisonCarteNouveauStatus()
        {
            //Création du Poison_Attack
            Power poisonAttackPower = new Power
            {
                Id = Power.POISON_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = poisonAttackPower,
                CardId= _cardA.Id,
                Card = _cardA,
                Value =3

            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

           // _playableCardB.Health = _playableCardA.Attack;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                int id = _playableCardB.CardStatus.Where(s => s.StatusId == Status.POISONX_ID).First().StatusId;
                Assert.AreEqual(Status.POISONX_ID, id);
                //TODO: Vérifier que la valeur du poison est bonne
                Assert.AreEqual(3, _playableCardB.GetStatusValue(Status.POISONX_ID));
            }




        }

        //Test pour stacker le Poison sur une carte

        [TestMethod]
        public void ApplyPoisonStackStatus()
        {
            //Création du Poison_Attack
            Power poisonAttackPower = new Power
            {
                Id = Power.POISON_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = poisonAttackPower,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //Création du Status 
            Status Poison = new Status
            {
                Id = Status.POISONX_ID
            };


            //Création du CardStatus + ajout à la carte B
            CardStatus poisonStatus = new CardStatus
            {

            };

            

           // _playableCardB.Health = _playableCardA.Attack;



            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);





            //Modifier la vérfication
            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);
            //TODO:  Ajouter vérification que le poison a stack
            Assert.AreEqual(5, _playableCardB.GetStatusValue(Status.POISONX_ID));



        }

        //test pour le PoisonDamageEvent
        [TestMethod]
        public void PoisonnedCardDmg()
        {
         
            //Création du status Stun
            Status poison = new Status
            {
                Id = Status.POISONX_ID

            };

            //Création du CardStatus
            CardStatus poisonStatus = new CardStatus
            {
                PlayableCardId = _playableCardA.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 2
            };
            _playableCardA.CardStatus = new List<CardStatus> { poisonStatus };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(CardBHp, _playableCardB.Health);
            }




        }

        //test pour vérifier que le stack de poison a été réduit de 1 après la fin d'un round
        [TestMethod]
        public void PoisonStackReduced()
        {

            //Création du status Stun
            Status poison = new Status
            {
                Id = Status.POISONX_ID

            };

            //Création du CardStatus
            CardStatus cardStatusStunned = new CardStatus
            {
                PlayableCardId = _playableCardA.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 4
            };
            _playableCardA.CardStatus = new List<CardStatus> { cardStatusStunned };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
            //round de l'autre joueur
            var playerTurnEvent2 = new PlayerEndTurnEvent(_match,  _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée

                Assert.AreEqual(3, _playableCardB.GetStatusValue(Status.POISONX_ID));
              
            }




        }

        //test pour vérifier la mort d'un PoisonDamageEvent


        //TODO 2 : Faire les tests pour le power Chaos

        //test pour l'application du chaos à une carte (se produit avant que la carte attaque)
        [TestMethod]
        public void AddChaosToCard()
        {
            //Création du pouvoir Chaos
            Power ChaosPower = new Power
            {
                Id = Power.CHAOS_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = ChaosPower,
                CardId = _cardA.Id,
                Card = _cardA
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //on stocke les valeurs inversées prévues de la carte pour la vérification
            var newHealth = _playableCardB.Attack;
            var newAttack = _playableCardB.Health;

            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


            Assert.AreEqual(newHealth, _playableCardB.Health);
            Assert.AreEqual(newAttack, _playableCardB.Attack);

        }

        //test qu'un carte avec 0 d'attaque meurt instantanément
        [TestMethod]
        public void Chaos0DmgCard()
        {
            //Création du pouvoir Chaos
            Power ChaosPower = new Power
            {
                Id = Power.CHAOS_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = ChaosPower,
                CardId = _cardA.Id,
                Card = _cardA
              
            };


            //Création d'un nouvelle carte avec 0 de dmg
            Card noDmgCard = new Card
            {
                Name = "The Wall",
                Attack = 0,
                Health = 12,
                Cost = 7,
                ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png"

            };
            //Création d'un nouvelle PlayableCard avec la Card
            PlayableCard newCard = new PlayableCard(noDmgCard);

           
        
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //on stocke les valeurs inversées prévues de la carte pour la vérification
          //  var newHealth = _playableCardB.Attack;
          //  var newAttack = _playableCardB.Health;

            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(_playableCardA);
            //Ajout de la carte avec 0 dmg à la liste du joueur B 
            _opposingPlayerData.BattleField.Add(newCard);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


          //  Assert.AreEqual(newHealth, _playableCardB.Health);
          //  Assert.AreEqual(newAttack, _playableCardB.Attack);
            AssertCurrentPlayerCardDied();
        }

        //TODO 3: Faire les tests pour le status Stunned

        //Test pour vérifier qu'une carte a été stunned
        [TestMethod]
        public void ApplyStunNewStatus()
        {
            //Création du Poison_Attack
            Power stunAttackPower = new Power
            {
                Id = Power.STUN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = stunAttackPower,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 2

            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            // _playableCardB.Health = _playableCardA.Attack;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                int id = _playableCardB.CardStatus.Where(s => s.StatusId == Status.STUNNEDX_ID).First().StatusId;
                Assert.AreEqual(Status.STUNNEDX_ID, id);
                //TODO: Vérifier que la valeur du stun est bonne
            }




        }

        //Test pour vérifier que la carte stunned n'a pas été activée
        [TestMethod]
        public void StunnedCardDidNotAttack()
        {
            //Création du Poison_Attack
            Power stunAttackPower = new Power
            {
                Id = Power.STUN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = stunAttackPower,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 2

            };
            _cardA.CardPowers = new List<CardPower> { cardPower };


            //Création du status Stun
            Status stunned = new Status
            {
                Id = Status.STUNNEDX_ID

            };

            //Création du CardStatus
            CardStatus cardStatusStunned = new CardStatus
            {
                PlayableCardId = _playableCardA.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.STUNNEDX_ID,
                Status = stunned
            };
            _playableCardA.CardStatus = new List<CardStatus> { cardStatusStunned };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                    //Aller chercher la liste de CardActivationEvent et vérifier qu'aucune d'entre elle ne provient de la carte stunned (cardId)

                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(CardBHp, _playableCardB.Health);
            }




        }


        //test pour vérifier que le stack de Stun a été réduit de 1 après la fin d'un round

        [TestMethod]
        public void StunnedCardStackReduced()
        {
            //Création du Poison_Attack
            Power stunAttackPower = new Power
            {
                Id = Power.STUN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = stunAttackPower,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 2

            };
            _cardA.CardPowers = new List<CardPower> { cardPower };


            //Création du status Stun
            Status stunned = new Status
            {
                Id = Status.STUNNEDX_ID

            };

            //Création du CardStatus
            CardStatus cardStatusStunned = new CardStatus
            {
                PlayableCardId = _playableCardA.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.STUNNEDX_ID,
                Status = stunned
            };
            _playableCardA.CardStatus = new List<CardStatus> { cardStatusStunned };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(2, _playableCardB.GetStatusValue(Status.POISONX_ID));
            var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);


            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(1, _playableCardB.GetStatusValue(Status.STUNNEDX_ID));
            }




        }


        //TODO: Ajouter des tests pour le DamageDown


    }
}
