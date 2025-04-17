using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType => "Combat";

        public CombatEvent(Match match , MatchPlayerData CurrentPlayer,MatchPlayerData OppositePlayer)
        {
            var attacker = CurrentPlayer;
            var defender = OppositePlayer;

            Events = new List<MatchEvent>
        {
            new CardActivationEvent(match, attacker, defender)
        };
        }
    }
}
