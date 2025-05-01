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
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //Création du Status 


            //Création du CardStatus + ajout à la carte B


            

           // _playableCardB.Health = _playableCardA.Attack;



            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);





            //Modifier la vérfication
            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);
           //TODO:  Ajouter vérification que le poison a stack




        }

        //test pour le PoisonDamageEvent

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
                Card = _cardA
              
            };

            
            //Création d'un nouvelle carte avec 0 de dmg
            Card

            //Création d'un nouvelle PlayableCard avec la Card

            //Ajout de la ClayableCard à la liste du joueur B 
        
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

        //TODO 3: Faire les tests pour le status Stunned

        //Test pour vérifier qu'une carte a été stunned


        //Test pour vérifier que la carte stunned n'a pas été activée

    }
}
