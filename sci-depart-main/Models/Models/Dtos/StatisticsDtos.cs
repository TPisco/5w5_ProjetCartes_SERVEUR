using Super_Cartes_Infinies.Models;

namespace Models.Models.Dtos
{
    public class ChartDataPoint
    {
        public string Label { get; set; } = "";
        public int Count { get; set; }
    }

    public class PlayerStatisticsDto
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Gold { get; set; }
        public List<DeckStatisticsDto> Decks { get; set; } = new();
    }

    public class DeckStatisticsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class CardDistributionDto
    {
        public List<ChartDataPoint> ByCost { get; set; } = new();
        public List<ChartDataPoint> ByRarity { get; set; } = new();
        public List<ChartDataPoint> ByAttack { get; set; } = new();
        public List<ChartDataPoint> ByHealth { get; set; } = new();
    }

    public class PackPurchaseResultDto
    {
        public int GoldRemaining { get; set; }
        public List<Card> Cards { get; set; } = new();
    }
}
