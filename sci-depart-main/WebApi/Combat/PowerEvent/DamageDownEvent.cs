using Microsoft.AspNetCore.Components.Web.Virtualization;
using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Combat.PowerEvent
{
    public class DamageDownEvent : MatchEvent
    {
        public override string EventType => "DamageDown";


        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Damage { get; set; }

        //A MODIFIER

        //Uniquement réduire valeur ici à chaque round
        public DamageDownEvent(PlayableCard attackingCard,PlayableCard defendingCard, MatchPlayerData defender)
        {
            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            // Value = defendingCard.GetStatusValue(Status.DAMAGE_DOWNX_ID);

            //Faire nouveau dmg temporaire  : currentdmg -DmgDown
            var reducedDmg = attackingCard.Attack - attackingCard.GetStatusValue(Status.DAMAGE_DOWNX_ID);
            Damage = reducedDmg;
            //Appeler un CardDamageEvent avec nouveau dmg temporaire
            Events.Add(new CardDamageEvent(Damage, defendingCard, defender));

            CardStatus status = attackingCard.CardStatus.Where(c => c.StatusId == Status.DAMAGE_DOWNX_ID).First();
     
            if (status.Value - 1 <= 0)
            {
                attackingCard.CardStatus.Remove(status);
            }
            else
            {
                status.Value--;
            }
        }

    }
}

