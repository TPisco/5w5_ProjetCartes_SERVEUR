using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ShieldEvent : MatchEvent
    {
        public override string EventType => "Shield";
        public int CardId { get; set; }
        public int PlayerId { get; set; }
        public int Shield { get; set; }

        public ShieldEvent(MatchPlayerData player, PlayableCard card)
        {
            //a terminer mettre power id a SHILD_ID
            CardId = card.Id;
            PlayerId = player.PlayerId;
            Shield = card.GetPowerValue(Power.SHIELD_ID);
            card.Health += Shield;
        }
    }
}