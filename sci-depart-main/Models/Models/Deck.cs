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

      //  public bool Courant { get; set; }

        //Liste de DeckCards
        [JsonIgnore]
        public virtual List<DeckCards> DeckCards { get; set; }


        public bool IsCurrent { get; set; }
    }
}
