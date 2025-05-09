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
                Assert.AreEqual(2, _playableCardB.GetStatusValue(Status.POISONX_ID));
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
                StatusId = Status.POISONX_ID,
                Status = Poison,
               PlayableCard = _playableCardB, 
               
                Value = 3
            };

            _playableCardB.CardStatus = new List<CardStatus> { poisonStatus };

           // _playableCardB.Health = _playableCardA.Attack;



            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);





            //Modifier la vérfication
            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);
            //TODO:  Ajouter vérification que le poison a stack (doit être 5 au lieu de 6, puisque la valeur du poison aura baissé à la fin du round
            Assert.AreEqual(5, _playableCardB.GetStatusValue(Status.POISONX_ID));



        }

        //test pour le PoisonDamageEvent
        [TestMethod]
        public void PoisonnedCardDmg()
        {
         
            //Création du status Poison
            Status poison = new Status
            {
                Id = Status.POISONX_ID

            };

            //Création du CardStatus
            CardStatus poisonStatus = new CardStatus
            {
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 2
            };
            _playableCardB.CardStatus = new List<CardStatus> { poisonStatus };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

           // _currentPlayerData.BattleField.Add(_playableCardA);
            _currentPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(CardBHp - 2, _playableCardB.Health);
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
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 4
            };
            _playableCardB.CardStatus = new List<CardStatus> { cardStatusStunned };

            //Stocker les Hp de la carte B
            var CardBHp = _playableCardB.Health;

          //  _currentPlayerData.BattleField.Add(_playableCardA);
            _currentPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData,  NB_MANA_PER_TURN);

           //Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
            //round de l'autre joueur
           // var playerTurnEvent2 = new PlayerEndTurnEvent(_match,  _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée

                Assert.AreEqual(3, _playableCardB.GetStatusValue(Status.POISONX_ID));
              
            } else
            {
                Assert.Fail();
            }




        }

        //test pour vérifier qu'une carte n'a plus l'effet de poison quand la valeur est = à 0
        [TestMethod]
        public void PoisonnedCardNoMoreStatus()
        {

            //Création du status Poison
            Status poison = new Status
            {
                Id = Status.POISONX_ID

            };

            //Création du CardStatus
            CardStatus cardStatusStunned = new CardStatus
            {
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 1
            };
            _playableCardB.CardStatus = new List<CardStatus> { cardStatusStunned };

            //_currentPlayerData.BattleField.Add(_playableCardA);
            _currentPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            //Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
            //round de l'autre joueur
           // var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);

                Assert.IsFalse(_playableCardB.HasStatus(Status.POISONX_ID));

           




        }
        //Test pour vérifier qu'une carte n'a pas pu attaquer si elle meurt par le poison avant son attaque

        //[TestMethod]
        //public void PoisonnedCardNoAttackIfDead()
        //{

        //    //Création du status Poison
        //    Status poison = new Status
        //    {
        //        Id = Status.POISONX_ID

        //    };

        //    //Création du CardStatus
        //    CardStatus cardStatusStunned = new CardStatus
        //    {
        //        PlayableCardId = _playableCardA.Id,
        //        PlayableCard = _playableCardB,
        //        StatusId = Status.POISONX_ID,
        //        Status = poison,
        //        Value = 30
        //    };
        //    _playableCardA.CardStatus = new List<CardStatus> { cardStatusStunned };

        //    //Stocker les Hp de la carte B
        //    var CardBHp = _playableCardB.Health;

        //    _currentPlayerData.BattleField.Add(_playableCardA);
        //    _opposingPlayerData.BattleField.Add(_playableCardB);
        //    var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

        //    //Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
        //    //round de l'autre joueur
        //    //var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);



        //    if (_playableCardB.CardStatus != null)
        //    {
        //        //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
        //        //Aussi vrifier que la carte n'a pas été activée

              
        //        Assert.AreEqual(CardBHp, _playableCardB.Health);
        //    }




        //}

        //test pour vérifier la mort d'un PoisonDamageEvent
        [TestMethod]
        public void PoisonnedCardDeath()
        {

            //Création du status Poison
            Status poison = new Status
            {
                Id = Status.POISONX_ID

            };

            //Création du CardStatus
            CardStatus poisonStatus = new CardStatus
            {
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.POISONX_ID,
                Status = poison,
                Value = 30
            };
            _playableCardB.CardStatus = new List<CardStatus> { poisonStatus };

          
          //  _currentPlayerData.BattleField.Add(_playableCardA);
            _currentPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            //Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
            //round de l'autre joueur
           // var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);


                AssertOpposingPlayerCardDied();
            




        }

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
            //Création du Stun_Attack
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
                Value = 3

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
                Assert.AreEqual(3, _playableCardB.GetStatusValue(Status.STUNNEDX_ID));
            }





        }

        [TestMethod]
        public void AplyStunStackStatus()
        {
            //Création du Stun Attack
            Power stun = new Power
            {
                Id = Power.STUN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = stun,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //Création du Status 
            Status stunned = new Status
            {
                Id = Status.STUNNEDX_ID
            };


            //Création du CardStatus + ajout à la carte B
            CardStatus poisonStatus = new CardStatus
            {
                StatusId = Status.STUNNEDX_ID,
                Status = stunned,
                PlayableCard = _playableCardB,

                Value = 3
            };

            _playableCardB.CardStatus = new List<CardStatus> { poisonStatus };

            // _playableCardB.Health = _playableCardA.Attack;



            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);





            //Modifier la vérfication
            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);
            //TODO:  Ajouter vérification que le poison a stack (doit être 5 au lieu de 6, puisque la valeur du poison aura baissé à la fin du round
            Assert.AreEqual(6, _playableCardB.GetStatusValue(Status.STUNNEDX_ID));



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
            var CardAHp = _playableCardA.Health;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                    //Aller chercher la liste de CardActivationEvent et vérifier qu'aucune d'entre elle ne provient de la carte stunned (cardId)

                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(CardAHp, _playableCardA.Health);
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
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.STUNNEDX_ID,
                Status = stunned
            };
            _playableCardB.CardStatus = new List<CardStatus> { cardStatusStunned };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

          //  Assert.AreEqual(2, _playableCardB.GetStatusValue(Status.STUNNEDX_ID));
          //  var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);


            if (_playableCardB.CardStatus != null)
            {
                //TODO : Vérifier que la carte défense n'a pas recu aucun dégâts
                //Aussi vrifier que la carte n'a pas été activée
                Assert.AreEqual(1, _playableCardB.GetStatusValue(Status.STUNNEDX_ID));
            }




        }

        //Test pour vérifier que la carte n'as plus l'effet Stunned quand sa valeur est = à 0
        [TestMethod]
        public void StunnedCardNoMoreStatus()
        {
            //Création du StunAttack
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
                Value = 1

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
                PlayableCardId = _playableCardB.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.STUNNEDX_ID,
                Status = stunned
            };
            _playableCardB.CardStatus = new List<CardStatus> { cardStatusStunned };


            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

           // Assert.AreEqual(2, _playableCardB.GetStatusValue(Status.POISONX_ID));
            var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);



                Assert.IsFalse(_playableCardB.HasStatus(Status.STUNNEDX_ID));
            

        }

        //TODO 4 : Ajouter des tests pour le DamageDown

        //test pour appliquer le DamageDown
        [TestMethod]
        public void ApplyDamageDownNewStatus()
        {
            //Création du Poison_Attack
            Power damageDown = new Power
            {
                Id = Power.DAMAGE_DOWN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = damageDown,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 3

            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            // _playableCardB.Health = _playableCardA.Attack;

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);



            if (_playableCardB.CardStatus != null)
            {
                int id = _playableCardB.CardStatus.Where(s => s.StatusId == Status.DAMAGE_DOWNX_ID).First().StatusId;
                Assert.AreEqual(Status.DAMAGE_DOWNX_ID, id);
                //TODO: Vérifier que la valeur du poison est bonne
                Assert.AreEqual(3, _playableCardB.GetStatusValue(Status.DAMAGE_DOWNX_ID));
            }




        }





        //test pour vérifier que le carte inflige désormais moins de dégâts

        [TestMethod]
        public void DamageDownWorks()
        {
            //Création du pouvoir DamageDown
            Power DamageDown = new Power
            {
                Id = Power.DAMAGE_DOWN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = DamageDown,
                CardId = _cardA.Id,
                Card = _cardA,
                  Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

           
            var oldAttack = _playableCardB.Attack;
          

            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


            Assert.AreEqual(oldAttack -3 , _playableCardB.Attack);
           

        }


        [TestMethod]
        public void ApplyDamageDownStackStatus()
        {
            //Création du DamageDownAttack
            Power dmgdown = new Power
            {
                Id = Power.DAMAGE_DOWN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = dmgdown,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            //Création du Status 
            Status dmgStatus = new Status
            {
                Id = Status.DAMAGE_DOWNX_ID
            };


            //Création du CardStatus + ajout à la carte B
            CardStatus DamageDownStatus = new CardStatus
            {
                StatusId = Status.DAMAGE_DOWNX_ID,
                Status = dmgStatus,
                PlayableCard = _playableCardB,

                Value = 3
            };

            _playableCardB.CardStatus = new List<CardStatus> { DamageDownStatus };

            // _playableCardB.Health = _playableCardA.Attack;



            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);





            //Modifier la vérfication
            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);
            //TODO:  Ajouter vérification que le poison a stack (doit être 5 au lieu de 6, puisque la valeur du poison aura baissé à la fin du round
            Assert.AreEqual(6, _playableCardB.GetStatusValue(Status.DAMAGE_DOWNX_ID));



        }


        //test pour vérifier que l'effet n'a PAS été réduit à la fin d'un round ( reste statique jusqu'à ce que l'effet disparait)
        [TestMethod]
        public void DamageDownStatusReduced()
        {
            //Création du pouvoir DamageDown
            Power DamageDown = new Power
            {
                Id = Power.DAMAGE_DOWN_ATTACK_ID
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = DamageDown,
                CardId = _cardA.Id,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };


            var oldAttack = _playableCardB.Attack;


            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


            Assert.AreEqual(2, _playableCardB.Attack);


        }

        //test pour vérifier que la carte n'a plus l'effet DamageDown quand sa valeur est = à 0

        [TestMethod]
        public void DamageDownCardNoMoreStatus()
        {

            //Création du status DamageDown
            Status dmgDown = new Status
            {
                Id = Status.DAMAGE_DOWNX_ID

            };

            //Création du CardStatus
            CardStatus cardStatusStunned = new CardStatus
            {
                PlayableCardId = _playableCardA.Id,
                PlayableCard = _playableCardB,
                StatusId = Status.DAMAGE_DOWNX_ID,
                Status = dmgDown,
                Value = 1
            };
            _playableCardA.CardStatus = new List<CardStatus> { cardStatusStunned };

            _currentPlayerData.BattleField.Add(_playableCardA);
            _opposingPlayerData.BattleField.Add(_playableCardB);
            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            //Assert.AreEqual(4, _playableCardB.GetStatusValue(Status.POISONX_ID));
            //round de l'autre joueur
            var playerTurnEvent2 = new PlayerEndTurnEvent(_match, _opposingPlayerData, _currentPlayerData, NB_MANA_PER_TURN);

                Assert.IsFalse(_playableCardB.HasStatus(Status.DAMAGE_DOWNX_ID));

            





        }


        //TODO 5 : Ajouter des tests pour les deux Spells

        //test pour le RandomPain
        [TestMethod]
        public void RandomPain()
        {
            //Création du pouvoir Chaos
            Power randomPain = new Power
            {
                Id = Power.RANDOMPAIN_ID,
                IsSpell = true
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = randomPain,
                CardId = _cardA.Id,
                Card = _cardA
              

            };


            //Création d'un nouvelle carte avec 0 de dmg
            Card spellCard = new Card
            {
                Name = "RandomOuch",
                Attack = 0,
                Health = 1,
                Cost = 4,
                ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png",
                

            };
            //Création d'un nouvelle PlayableCard avec la Card
            PlayableCard newCard = new PlayableCard(spellCard);



            _cardA.CardPowers = new List<CardPower> { cardPower };

            //on stocke les valeurs inversées prévues de la carte pour la vérification
            //  var newHealth = _playableCardB.Attack;
            //  var newAttack = _playableCardB.Health;

            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(newCard);
            //Ajout de la carte avec 0 dmg à la liste du joueur B 
            var oldHp = _playableCardB.Health;
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


            //  Assert.AreEqual(newHealth, _playableCardB.Health);
            //  Assert.AreEqual(newAttack, _playableCardB.Attack);
            AssertCurrentPlayerCardDied();
            Assert.AreNotEqual(oldHp, _playableCardB.Health);
        }


        //test pour le earthquake

        [TestMethod]
        public void EarthQuake_X()
        {
            //Création du pouvoir Chaos
            Power randomPain = new Power
            {
                Id = Power.EARTHQUAKEX_ID,
                IsSpell = true
            };

            //Création du CardPower pour la carte attaquante
            CardPower cardPower = new CardPower
            {
                Power = randomPain,
                CardId = _cardA.Id,
                Card = _cardA,
                Value =4


            };


            //Création d'un nouvelle carte avec 0 de dmg
            Card spellCard = new Card
            {
                Name = "EarthQuake",
                Attack = 0,
                Health = 1,
                Cost = 4,
                ImageUrl = "https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/006_f2.png",


            };
            //Création d'un nouvelle PlayableCard avec la Card
            PlayableCard newCard = new PlayableCard(spellCard);



            _cardA.CardPowers = new List<CardPower> { cardPower };

            //on stocke les valeurs inversées prévues de la carte pour la vérification
            var newHealthCardA = _playableCardB.Health - 4;
            var newHealthcardB = _playableCardB.Health - 4;

            //Ajout des cartes sur le terrain 
            _currentPlayerData.BattleField.Add(newCard);
            //Ajout de la carte avec 0 dmg à la liste du joueur B 
            var oldHp = _playableCardB.Health;
            _opposingPlayerData.BattleField.Add(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);


            Assert.AreEqual(newHealthCardA, _playableCardA.Health);
            Assert.AreEqual(newHealthcardB, _playableCardB.Health);

        }


    }
}
