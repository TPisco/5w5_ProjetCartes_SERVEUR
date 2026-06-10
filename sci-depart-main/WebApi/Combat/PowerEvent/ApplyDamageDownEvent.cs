using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ApplyDamageDownEvent :MatchEvent
    {
        public override string EventType => "ApplyDmgDown";

        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Value { get; set; }

        //Attack = PlayableCard.Attack - Value des stacks du status au total
        public ApplyDamageDownEvent(PlayableCard attackingCard, PlayableCard defendingCard, MatchPlayerData defender)
        {
            

            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            var dmgDownValueToAdd = attackingCard.GetPowerValue(Power.DAMAGE_DOWN_ATTACK_ID);
            //SI la carte a déjà du DamageDown, l'ajouter au stack
            if (defendingCard.HasStatus(Status.DAMAGE_DOWNX_ID))
            {
                //Aller chercher le status de la carte victime (utiliser un first???)
                CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.DAMAGE_DOWNX_ID).First();
                status.Value += dmgDownValueToAdd;

            }
            else
            {
                //Sinon, créer un nouveau CardStatus pour la carte victime
                //TODO : AJOUTER LE STATUS MANQUANT
                CardStatus cardStatus = new CardStatus
                {
                    PlayableCardId = defendingCard.Id,
                    
                    Value = dmgDownValueToAdd,
                    StatusId = Status.DAMAGE_DOWNX_ID,
                 
                };
                defendingCard.CardStatus.Add(cardStatus);


            }

        }

    }
}
