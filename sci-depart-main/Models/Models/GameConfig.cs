using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class GameConfig
    {
        public GameConfig() { }

        public int id { get; set; }

        public int QtManaParTour { get; set; }

        public int nbCardsToDraw { get; set; }
    }
}
