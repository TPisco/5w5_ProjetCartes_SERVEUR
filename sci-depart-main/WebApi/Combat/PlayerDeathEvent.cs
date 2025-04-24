using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayerDeathEvent : MatchEvent
    {
        public override string EventType => "PlayerDeath";
        public int DeadPlayerId { get; set; }
        public int WinningPlayerId { get; set; }

        public PlayerDeathEvent(Match match, MatchPlayerData attacker, MatchPlayerData defender)
        {
            DeadPlayerId = defender.PlayerId;
            WinningPlayerId = attacker.PlayerId;

            Events = new List<MatchEvent>
        {
            new EndMatchEvent(match, attacker, defender)
        };
        }
    }
}
