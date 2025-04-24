using Microsoft.AspNetCore.Mvc;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerStartTurnEvent : MatchEvent
    {
        public override string EventType { get { return "PlayerStartTurn"; } }
        public int PlayerId { get; set; }

        MatchConfigurationService _matchConfigurationService { get; set; }
        // L'évènement lorsqu'un joueur débutte son tour
        public PlayerStartTurnEvent( MatchPlayerData playerData, int nbManaPerTurn)
        {
            this.PlayerId = playerData.PlayerId;
            this.Events = new List<MatchEvent>();

           

            // TODO: Faire piger UNE carte (celle qui est pigé à chaque début de tour)
            DrawCardEvent dCE = new DrawCardEvent(playerData);
            this.Events.Add(dCE);

            // TODO: Faire gagner le Mana selon la configuration
            GainManaEvent gME = new GainManaEvent(playerData,nbManaPerTurn);
            this.Events.Add(gME);
        }

    }
}
