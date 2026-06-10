using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class Player : IModel
    {
		public Player()
		{
			ELO = 1000;
			Gold = 300;
		}

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public required string UserId { get; set; }
		[JsonIgnore]
		public virtual IdentityUser User { get; set; }

        public virtual List<OwnedCards> OwnedCards { get; set; }

		//Ajout d'une liste de decks , ù supprimer si cause des problùmes
		[JsonIgnore]
		public virtual List<Deck> Decks { get; set; }

		public int ELO { get; set; }
		public int Gold { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
    }
}

