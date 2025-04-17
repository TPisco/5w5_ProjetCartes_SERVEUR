using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType => "Combat";

        public CombatEvent(Match match)
        {
            var attacker = match.IsPlayerATurn ? match.PlayerDataA : match.PlayerDataB;
            var defender = match.IsPlayerATurn ? match.PlayerDataB : match.PlayerDataA;

            Events = new List<MatchEvent>
        {
            new CardActivationEvent(match, attacker, defender)
        };
        }
    }
}
