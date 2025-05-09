using Microsoft.AspNetCore.Components.Web.Virtualization;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class DamageDownEvent : MatchEvent
    {
        public override string EventType => "DamageDown";


        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Value { get; set; }


        public DamageDownEvent(PlayableCard defendingCard, MatchPlayerData defender)
        {
            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            Value = defendingCard.GetStatusValue(Status.POISONX_ID);
           // var reducedDmgValue = 
            var oldDmg = defendingCard.Attack;
            //Valeur de l'effet de poison
            CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.POISONX_ID).First();
            //TODO : Vérifier la logique du CardDamageEvent
            defendingCard.Attack = oldDmg - Value;
            //Réduire la valeur du poison. Si le poison est = à 0, retirer le status de la carte
            if (status.Value - 1 <= 0)
            {
                defendingCard.CardStatus.Remove(status);
            }
            else
            {
                status.Value--;
            }
        }

    }
}
}
