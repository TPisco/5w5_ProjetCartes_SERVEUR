using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ApplyStunEvent : MatchEvent
    {
        public override string EventType => "Stun";
        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public ApplyStunEvent(PlayableCard attackingCard, PlayableCard defendingCard, MatchPlayerData defender)
        {
            //À COMPLÉTER
        }


    }

    


    }
