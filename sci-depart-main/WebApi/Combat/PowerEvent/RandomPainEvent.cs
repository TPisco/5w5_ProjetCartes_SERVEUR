using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace WebApi.Combat.PowerEvent
{
    public class RandomPainEvent : MatchEvent
    {
        public override string EventType => "RandomPain";

        public int SpellCardId { get; set; }

        public int Damage { get; set; }

        //Logique : la carte qui contient le pouvoir RandomPain meurt instantanément après son utilisation

        public RandomPainEvent(PlayableCard spellCard, MatchPlayerData attacker ,PlayableCard defendingCard, MatchPlayerData defender)
        {
            Random r = new Random();
            
            int randomDamage = r.Next(1, 6);
            Damage = randomDamage;
            SpellCardId = spellCard.Id;
            Events.Add(new CardDamageEvent(randomDamage, defendingCard, defender));


            Events.Add(new CardDeathEvent(attacker,spellCard));
        }

    }
}
