using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OwnedCard
    {
        public int id { get; set; }

        public int CardId { get; set; }

        public int PlayerId { get; set; }
    }
}
