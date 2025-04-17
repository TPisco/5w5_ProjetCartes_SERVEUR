using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayerDamageEvent : MatchEvent
    {
        public override string EventType => "PlayerDamage";
        public int PlayerId { get; set; }
        public int Damage { get; set; }

        public PlayerDamageEvent( int damage, MatchPlayerData playerData, Match match,MatchPlayerData oppositePlayer)
        {
            PlayerId = playerData.Id;
            Damage = damage;
            if (playerData.Health - damage < 0)
            {
                playerData.Health = 0;
            }
            else { playerData.Health -= damage; }


            if (playerData.Health <= 0)
            {
                Events = new List<MatchEvent>
            {
                new PlayerDeathEvent(match,oppositePlayer,playerData)
            };
            }
        }
    }
}
