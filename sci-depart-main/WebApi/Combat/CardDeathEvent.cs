using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CardDeathEvent : MatchEvent
    {
        public override string EventType => "CardDeath";
        public int CardId { get; set; }
        public int PlayerId { get; set; }

        public CardDeathEvent(MatchPlayerData playerData, PlayableCard card)
        {
            CardId = card.Id;
            PlayerId = playerData.Id;

            if (playerData != null)
            {
                    playerData.Graveyard.Add(card);
                    playerData.BattleField.Remove(card);
            }
        }
    }
}
