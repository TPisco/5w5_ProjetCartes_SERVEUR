using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Power
    {

        public const int FIRST_STRIKE_ID = 1;
        public const int THORNS_ID = 2;
        public const int HEAL_ID = 3;
        public const int SHIELD_ID = 4;
        public const int CHAOS_ID = 5;
        public const int EARTHQUAKEX_ID = 6;
        public const int RANDOMPAIN_ID = 7;
        //Ajout des pouvoir de status
        public const int POISON_ATTACK_ID = 8;
        public const int STUN_ATTACK_ID = 9;
        //Ajout de mon propre Status : DamageDown
        public const int DAMAGE_DOWN_ATTACK_ID = 10;

        //Ajouter ces deux nouveaux pouvoir dans le seed, ce pouvoir permet aux cartes d'appliquer du Status à une carte. Ex: 2 de poison attack
        //Rappel: Un status baisse de 1 stack à chaque round

        //Ajout des spells + Dans le seed

        public int Id { get; set; }
        
        public int Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public virtual List<CardPower> cardPowers { get; set; }

        //Booléen pour vérifier si une carte est un Spell
        public bool IsSpell { get; set; } = false;

        //Pas supposé être là 
        public bool HasValue { get; set; }
    }
}
