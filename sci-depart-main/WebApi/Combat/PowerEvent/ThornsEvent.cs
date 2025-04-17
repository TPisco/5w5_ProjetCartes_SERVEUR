using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType => "Thorns";
        public int SourceCardId { get; set; }
        public int TargetCardId { get; set; }
        public int Damage { get; set; }
        public int AttackingPlayerId { get; set; }

        public ThornsEvent(PlayableCard source, PlayableCard target, MatchPlayerData attackingPlayer)
        {
            SourceCardId = source.Id;
            TargetCardId = target.Id;
            Damage = source.GetPowerValue(Power.THORNS_ID);
            AttackingPlayerId = attackingPlayer.Id;

           Events.Add( new CardDamageEvent(Damage, target, attackingPlayer));
        }
    }
}
