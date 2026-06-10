using System.ComponentModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
    public class Card:IModel
	{
		public Card() { }

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Attack { get; set; }
		public int Health { get; set; }
		public int Cost { get; set; }
        public string ImageUrl { get; set; } = "";
        public string Type { get; set; } = "";
        public CardRarity Rarity { get; set; } = CardRarity.Common;

        [ValidateNever]
        public virtual List<CardPower> CardPowers { get; set; }


		//Pas de status ici
		//List CardStatus


    }
}

