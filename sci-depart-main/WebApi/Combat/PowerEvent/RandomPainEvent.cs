using Super_Cartes_Infinies.Combat;

namespace WebApi.Combat.PowerEvent
{
    public class RandomPainEvent : MatchEvent
    {
        public override string EventType => "RandomPain";

        //Logique : la carte qui contient le pouvoir RandomPain meurt instantanément après son utilisation

    }
}
