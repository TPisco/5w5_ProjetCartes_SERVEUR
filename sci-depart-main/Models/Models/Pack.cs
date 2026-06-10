using System.Text.Json.Serialization;

namespace Models.Models
{
    public class Pack
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Price { get; set; }
        public int CardCount { get; set; }
        public CardRarity DefaultRarity { get; set; } = CardRarity.Common;

        [JsonIgnore]
        public virtual List<PackProbability> Probabilities { get; set; } = new();
    }
}
