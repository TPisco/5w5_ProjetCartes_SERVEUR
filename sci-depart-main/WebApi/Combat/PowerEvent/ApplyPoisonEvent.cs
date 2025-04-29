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

            //Requête LINQ pour chercher dans la liste de CardStatus de la carte le poison qu'il a déjà sur lui
            //PRendre la Value du poisonAttack : getPowerValue
            //Faire ci-dessus dans ApplyPoisonEvent ^^^^^^

            TargetCardId = defendingCard.Id;
            var poisonDmgToAdd = attackingCard.GetPowerValue(Power.POISON_ATTACK_ID);
            //SI la carte a déjà du poison, l'ajouter au stack
            if (defendingCard.HasStatus(Status.POISONX_ID))
            {
                //Aller chercher le status de la carte victime (utiliser un first???)
                CardStatus status = defendingCard.CardStatus.Where(c => c.StatusId == Status.POISONX_ID).First();
                status.Value += poisonDmgToAdd;

            }
            else
            {
                //Sinon, créer un nouveau CardStatus pour la carte victime
                //TODO : AJOUTER LE STATUS MANQUANT
                CardStatus cardStatus = new CardStatus
                {
                    PlayableCardId = defendingCard.Id,
                    PlayableCard = defendingCard,
                    Value = poisonDmgToAdd,
                    StatusId = Status.POISONX_ID,
                   // Status = 
                };
                defendingCard.CardStatus.Add(cardStatus);
              

            }

        }
    }
}
