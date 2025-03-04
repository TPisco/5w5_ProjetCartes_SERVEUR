using Microsoft.AspNetCore.Identity;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OwnedCards
    {
        public int id { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }
        public int PlayerId { get; set; }
    }
}
