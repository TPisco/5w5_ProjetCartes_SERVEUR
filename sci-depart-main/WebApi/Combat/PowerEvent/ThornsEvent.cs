using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ThornsEvent : MatchEvent
    {
        public override string EventType { get { return "ThornsEvent"; } }
        public int PlayerId { get; set; }

        public ThornsEvent(MatchPlayerData playerData) 
        { 
            PlayerId = playerData.PlayerId;

            // a faire pour HealEvent, ShieldEvent, FirstStrike
        }
    }
}
