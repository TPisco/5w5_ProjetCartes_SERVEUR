using System.Text.Json.Serialization;
using WebApi.Combat;
using WebApi.Combat.PowerEvent;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(DrawCardEvent))]
    [JsonDerivedType(typeof(EndMatchEvent))]
    [JsonDerivedType(typeof(GainManaEvent))]
    [JsonDerivedType(typeof(PlayerEndTurnEvent))]
    [JsonDerivedType(typeof(PlayerStartTurnEvent))]
    [JsonDerivedType(typeof(StartMatchEvent))]
    [JsonDerivedType(typeof(SurrenderEvent))]
    [JsonDerivedType(typeof(CombatEvent))]
    [JsonDerivedType(typeof(FirstStrikeEvent))]
    [JsonDerivedType(typeof(HealEvent))]
    [JsonDerivedType(typeof(ShieldEvent))]
    [JsonDerivedType(typeof(ThornsEvent))]
    [JsonDerivedType(typeof(CardActivationEvent))]
    [JsonDerivedType(typeof(CardDamageEvent))]
    [JsonDerivedType(typeof(CardDeathEvent))]
    [JsonDerivedType(typeof(PlayCardEvent))]
    [JsonDerivedType(typeof(PlayerDamageEvent))]
    [JsonDerivedType(typeof(PlayerDeathEvent))]
    public abstract class MatchEvent
    {
        public abstract string EventType { get; }

        public MatchEvent(){}

        public List<MatchEvent> Events { get; set; } = [];
    }
}
