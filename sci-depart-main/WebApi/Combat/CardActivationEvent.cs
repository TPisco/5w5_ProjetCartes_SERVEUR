using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using WebApi.Combat.PowerEvent;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType => "CardActivation";
        public int PlayerId { get; set; }

        public CardActivationEvent(Match match, MatchPlayerData attacker, MatchPlayerData defender)
        {
            PlayerId = attacker.PlayerId;
            Events = new List<MatchEvent>();

            for (int i = attacker.BattleField.Count - 1; i >= 0; i--)
            {
                var atkCard = attacker.BattleField[i];

                if (atkCard.HasPower(Power.HEAL_ID))
                    Events.Add(new HealEvent(attacker, atkCard));
                //Modifier apres avec SHIELD_ID
                if (atkCard.HasPower(3))
                    Events.Add(new ShieldEvent(attacker, atkCard));

                if (atkCard.HasPower(Power.FIRST_STRIKE_ID))
                {
                    Events.Add(new FirstStrikeEvent(match, attacker, defender, i));
                    continue;
                }

                if (i < defender.BattleField.Count)
                {
                    var defCard = defender.BattleField[i];

                    Events.Add(new CardDamageEvent(atkCard.Attack, defCard, defender));
                    Events.Add(new CardDamageEvent(defCard.Attack, atkCard, attacker));

                    if (defCard.HasPower(Power.THORNS_ID))
                    {
                        Events.Add(new ThornsEvent(defCard, atkCard, attacker));
                    }
                }
                else
                {
                    Events.Add(new PlayerDamageEvent(atkCard.Attack, defender, match, attacker));
                }
            }
        }
    }
}

