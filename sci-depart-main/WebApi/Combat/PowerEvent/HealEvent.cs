using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class HealEvent : MatchEvent
    {
        public override string EventType => "Heal";
        public int CardId { get; set; }
        public int PlayerId { get; set; }

        public HealEvent(MatchPlayerData player, PlayableCard card)
        {
            CardId = card.Id;
            PlayerId = player.PlayerId;
            int amount = card.GetPowerValue(Power.HEAL_ID);
            card.Health += amount;
        }
    }
}