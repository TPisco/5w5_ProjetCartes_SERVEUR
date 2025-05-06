using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.Combat.PowerEvent
{
    public class PoisonDamageEvent  :MatchEvent
    {
        public override string EventType => "PoisonDamage";

        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Damage { get; set; }


        public PoisonDamageEvent( PlayableCard defendingCard, MatchPlayerData defender)
        {
            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            Damage = defendingCard.GetStatusValue(Status.POISONX_ID);
            //Valeur de l'effet de poison
            CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.POISONX_ID).First();
            //TODO : Vérifier la logique du CardDamageEvent
            
            Events.Add(new CardDamageEvent(Damage, defendingCard, defender));
            //Réduire la valeur du poison. Si le poison est = à 0, retirer le status de la carte
            if(status.Value - 1 <= 0)
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
