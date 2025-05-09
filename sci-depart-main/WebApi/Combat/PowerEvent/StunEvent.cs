using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Combat.PowerEvent
{
    public class StunEvent  :MatchEvent
    {
        public override string EventType => "StunnedNoAttack";

        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Value { get; set; }


        public StunEvent( PlayableCard defendingCard, MatchPlayerData defender)
        {
            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            Value = defendingCard.GetStatusValue(Status.STUNNEDX_ID);
            //Valeur de l'effet de Stun
            CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.STUNNEDX_ID).First();

            //Réduire la valeur du Stun. Si le Stun est = à 0, retirer le status de la carte
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
