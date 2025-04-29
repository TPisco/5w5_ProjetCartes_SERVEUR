using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType => "PlayCard";
        public int playerId { get; set; }
        public int cardId { get; set; }

        public PlayCardEvent(Match match, MatchPlayerData currentPlayerData, int CardId)
        {
            Events = new List<MatchEvent>();

            var card = currentPlayerData.Hand.FirstOrDefault(c => c.Id == cardId);
            if (card == null || currentPlayerData.Mana < card.Card.Cost) return;

            cardId = CardId;

            playerId = currentPlayerData.PlayerId;

            currentPlayerData.Hand.Remove(card);
            currentPlayerData.BattleField.Add(card);

            currentPlayerData.Mana -= card.Card.Cost;


        }
    }
}