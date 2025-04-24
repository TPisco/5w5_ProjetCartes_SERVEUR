using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class FirstStrikeEvent : MatchEvent
    {
        public override string EventType => "FirstStrike";

        public FirstStrikeEvent(Match match, MatchPlayerData attacker, MatchPlayerData defender, int index)
        {
            Events = new List<MatchEvent>();

            if (index < defender.BattleField.Count)
            {
                var atkCard = attacker.BattleField[index];
                var defCard = defender.BattleField[index];

                Events.Add(new CardDamageEvent( atkCard.Attack, defCard, defender));
            }
        }
    }
}