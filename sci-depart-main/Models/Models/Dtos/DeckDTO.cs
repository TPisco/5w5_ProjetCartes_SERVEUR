using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Dtos
{
    public class DeckDTO
    {

        [Required]
        public string Deckname { get; set; } = null!;

        public string? ErrorMessage { get; set; }


    }
}
