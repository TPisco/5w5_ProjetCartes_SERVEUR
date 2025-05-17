using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class EarthquakeEvent : MatchEvent
    {
        public override string EventType => "EarthquakeX";

        //À COMPLÉTER...
        public List<PlayableCard> DefenderCards { get; set; }

        public List<PlayableCard> AttackerCards { get; set; }

        public int SpellCardId { get; set; }

        public int Damage { get; set; }

        // Prend la liste de toutes les cartes car elle inflige des dégâts à TOUTES les cartes sur le terrain
        public EarthquakeEvent(PlayableCard earthquakeCard, List<PlayableCard> attackerCards, List<PlayableCard> defenderCards, MatchPlayerData attacker, MatchPlayerData defender)
        {


            DefenderCards = defenderCards;
            AttackerCards = attackerCards;
            SpellCardId = earthquakeCard.Id;
            Damage = earthquakeCard.GetPowerValue(Power.EARTHQUAKEX_ID);

            // Appliquez l'effet Chaos aux cartes de l'attaquant
            ApplyEarthquakeDamage(attackerCards, attacker, Damage);

            // Appliquez l'effet Chaos aux cartes du défenseur
            ApplyEarthquakeDamage(defenderCards, defender, Damage);
        }

        // Méthode pour appliquer l'effet Chaos à une liste de cartes
        private void ApplyEarthquakeDamage(List<PlayableCard> cards, MatchPlayerData player, int damage)
        {

            List<PlayableCard> deadCards = new List<PlayableCard>();

            foreach (var card in cards)
            {
               
               

                if (card.Health - damage <= 0)
                {
                    deadCards.Add(card);
                }
                else
                {
                    Events.Add(new CardDamageEvent(damage, card, player));
                }

            }



            foreach (var dead in deadCards)
            {

                Events.Add(new CardDeathEvent(player, dead));
            }


        }



    }
}


}
