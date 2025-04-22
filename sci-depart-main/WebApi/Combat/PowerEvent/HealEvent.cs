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
        public int Heal {  get; set; }

        public HealEvent(MatchPlayerData player, PlayableCard card)
        {
            CardId = card.Id;
            PlayerId = player.PlayerId;
            Heal = card.GetPowerValue(Power.HEAL_ID);
            for(int i = player.BattleField.Count - 1; i >= 0; i--)
            {
                if(player.BattleField[i].Health+ Heal > player.BattleField[i].Card.Health)
                {
                    player.BattleField[i].Health = player.BattleField[i].Card.Health;
                }
                else { player.BattleField[i].Health += Heal; }
               
            }
            
        }
    }
}