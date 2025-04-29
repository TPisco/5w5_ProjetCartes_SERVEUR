using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ApplyPoisonEvent : MatchEvent
    {
        public override string EventType => "Poison";
        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }


        //À Mettre dans le PoisonDamageEvent
       // public int Poison { get; set; }

        public ApplyPoisonEvent(PlayableCard attackingCard, PlayableCard defendingCard)
        {
            //Créer un nouveau CardStatus


            //CardId = card.Id;
            //PlayerId = player.PlayerId;
            //Heal = card.GetPowerValue(Power.HEAL_ID);
            //for (int i = player.BattleField.Count - 1; i >= 0; i--)
            //{
            //    if (player.BattleField[i].Health + Heal > player.BattleField[i].Card.Health)
            //    {
            //        player.BattleField[i].Health = player.BattleField[i].Card.Health;
            //    }
            //    else { player.BattleField[i].Health += Heal; }

            //}

        }
    }
}
