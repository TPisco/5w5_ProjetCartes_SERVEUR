using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CardStatus
    {

        public int Id { get; set; }
        public int CardId { get; set; }

        [JsonIgnore]
        public virtual Card Card { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public int Value { get; set; }




    }
}
