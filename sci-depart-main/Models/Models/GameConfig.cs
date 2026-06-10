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
        public int GoldStarting { get; set; } = 300;
        public int GoldWin { get; set; } = 50;
        public int GoldLoss { get; set; } = 10;
        public int MaxDecks { get; set; } = 10;
        public int MaxCardsPerDeck { get; set; } = 30;
    }
}
