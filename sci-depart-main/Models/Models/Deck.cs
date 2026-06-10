using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Deck
    {

        public int Id { get; set; }

        //Nom du deck
        public string Name { get; set; }

        //Liste de DeckCards
        public virtual List<DeckCards> DeckCards { get; set; }


        public bool IsCurrent { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
