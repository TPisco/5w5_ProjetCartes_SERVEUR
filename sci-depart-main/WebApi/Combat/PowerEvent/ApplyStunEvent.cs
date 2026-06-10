using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ApplyStunEvent : MatchEvent
    {
        public override string EventType => "Stun";
        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Value { get; set; }
        public ApplyStunEvent(PlayableCard attackingCard, PlayableCard defendingCard, MatchPlayerData defender)
        {
            //À COMPLÉTER

            PlayerId = defender.PlayerId;
            TargetCardId = defendingCard.Id;
            var stunValueToAdd = attackingCard.GetPowerValue(Power.STUN_ATTACK_ID);
            Value = stunValueToAdd;
            //SI la carte a déjà du Stun, l'ajouter au stack
            if (defendingCard.HasStatus(Status.STUNNEDX_ID))
            {
                //Aller chercher le status de la carte victime (utiliser un first???)
                CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.STUNNEDX_ID).First();
                status.Value += stunValueToAdd;

            }
            else
            {
                //Sinon, créer un nouveau CardStatus pour la carte victime
                //TODO : AJOUTER LE STATUS MANQUANT
                CardStatus cardStatus = new CardStatus
                {
                    PlayableCardId = defendingCard.Id,
                    // PlayableCard = defendingCard,
                    Value = stunValueToAdd,
                    StatusId = Status.STUNNEDX_ID,
                    // Status =
                };
                defendingCard.CardStatus.Add(cardStatus);


            }

        }


    }

    


    }
