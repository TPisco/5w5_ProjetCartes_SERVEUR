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

        //A MODIFIER
        public DamageDownEvent(PlayableCard defendingCard, MatchPlayerData defender)
        {
            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            Value = defendingCard.GetStatusValue(Status.DAMAGE_DOWNX_ID);

            //  var oldDmg = defendingCard.Attack;


            //CODE À AJOUTER PLUS TARD:
            // Vérifiez la réduction déjà appliquée
            // int newReduction = Value - defendingCard.TotalDamageDown;

            // Appliquez uniquement la nouvelle réduction
            //if (newReduction > 0)
            //{
            //    defendingCard.Attack -= newReduction;
            //    defendingCard.TotalDamageDown += newReduction;
            //}


            CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.DAMAGE_DOWNX_ID).First();
     
          //  defendingCard.Attack = oldDmg - Value;
            //Réduire la valeur du DamageDown. Si le DamageDown est = à 0, retirer le status de la carte
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

