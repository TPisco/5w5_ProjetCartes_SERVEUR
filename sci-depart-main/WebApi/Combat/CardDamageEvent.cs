using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType => "CardDamage";
        public int Damage { get; set; }
        public int PlayerId { get; set; }

        public CardDamageEvent(int damage, PlayableCard card, MatchPlayerData playerData)
        {

            Damage = damage;
            PlayerId = playerData.Id;

            card.Health -= damage;

            if (card.Health <= 0)
            {
                Events = new List<MatchEvent>
            {
                new CardDeathEvent(playerData, card)
            };
            }
        }
    }
}