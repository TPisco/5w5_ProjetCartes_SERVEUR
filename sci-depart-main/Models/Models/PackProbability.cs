using System.Text.Json.Serialization;

namespace Models.Models
{
    public class PackProbability
    {
        public int Id { get; set; }
        public int PackId { get; set; }
        public CardRarity Rarity { get; set; }
        public double ProbabilityPercent { get; set; }

        [JsonIgnore]
        public virtual Pack Pack { get; set; } = null!;
    }
}
