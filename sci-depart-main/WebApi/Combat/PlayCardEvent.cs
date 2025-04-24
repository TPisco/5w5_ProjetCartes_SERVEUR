using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType => "PlayCard";
        public int PlayerId { get; set; }
        public int CardId { get; set; }

        public PlayCardEvent(Match match, MatchPlayerData currentPlayerData, int cardId)
        {
            Events = new List<MatchEvent>();

            var card = currentPlayerData.Hand.FirstOrDefault(c => c.Id == cardId);
            if (card == null || currentPlayerData.Mana < card.Card.Cost) return;

            PlayerId = currentPlayerData.PlayerId;
            CardId = cardId;

            currentPlayerData.Hand.Remove(card);
            currentPlayerData.BattleField.Add(card);
            currentPlayerData.Mana -= card.Card.Cost;


        }
    }
}