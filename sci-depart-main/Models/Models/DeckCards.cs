using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class DeckCards
    {

        public int Id { get; set; }

        // OwnedCard
        public virtual OwnedCards OwnedCard { get; set; }

        public int OwnedCardId { get; set; }

        //Deck Parent
        [JsonIgnore]
        public virtual Deck Deck { get; set; }

        public  int DeckId { get; set; }
    }
}
