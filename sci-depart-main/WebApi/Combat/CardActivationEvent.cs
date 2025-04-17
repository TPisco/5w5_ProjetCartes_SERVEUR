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

                
                //Modifier apres avec SHIELD_ID
                if (atkCard.HasPower(Power.SHIELD_ID))
                    Events.Add(new ShieldEvent(attacker, atkCard));

                if (i < defender.BattleField.Count)
                {
                    var defCard = defender.BattleField[i];

                    if (atkCard.HasPower(Power.FIRST_STRIKE_ID))
                    {
                        if ( defCard.Health- atkCard.Attack <= 0)
                        {
                            Events.Add(new FirstStrikeEvent(match, attacker, defender, i));
                            continue;
                        }
                    }

                    if (defCard.HasPower(Power.THORNS_ID))
                    {
                        Events.Add(new ThornsEvent(defCard, atkCard, attacker));
                        if (atkCard.Health - defCard.GetPowerValue(Power.THORNS_ID) <= 0) continue;
                    }

                    Events.Add(new CardDamageEvent(atkCard.Attack, defCard, defender));

                    if (atkCard.HasPower(Power.HEAL_ID))
                        Events.Add(new HealEvent(attacker, atkCard));

                    Events.Add(new CardDamageEvent(defCard.Attack, atkCard, attacker));

                   


                }
                else
                {
                    Events.Add(new PlayerDamageEvent(atkCard.Attack, defender, match, attacker));
                }
            }
        }
    }
}

