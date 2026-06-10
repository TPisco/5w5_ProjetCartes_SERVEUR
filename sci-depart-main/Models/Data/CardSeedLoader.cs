using System.Text.Json;
using Models.Models;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data;

public class PokemonCardSeedEntry
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Attack { get; set; }
    public int Health { get; set; }
    public int Cost { get; set; }
    public string Rarity { get; set; } = "Common";
    public string Type { get; set; } = "";
    public string ImageUrl { get; set; } = "";
}

public static class CardSeedLoader
{
    public const int DefaultPokemonCount = 400;
    private static Card[]? _cachedCards;

    public static Card[] LoadCards(int maxCount = DefaultPokemonCount)
    {
        _cachedCards ??= ReadEntries()
            .OrderBy(entry => entry.Id)
            .Take(DefaultPokemonCount)
            .Select(MapToCard)
            .ToArray();

        return _cachedCards.Take(maxCount).ToArray();
    }

    public static Card? FindByNationalDexId(int nationalDexId) =>
        LoadCards().FirstOrDefault(card => card.Id == nationalDexId);

    private static List<PokemonCardSeedEntry> ReadEntries()
    {
        using var stream = OpenSeedStream();
        var entries = JsonSerializer.Deserialize<List<PokemonCardSeedEntry>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (entries == null || entries.Count == 0)
        {
            throw new InvalidOperationException("pokemon_cards.json is empty or invalid.");
        }

        return entries;
    }

    private static Stream OpenSeedStream()
    {
        var assembly = typeof(CardSeedLoader).Assembly;
        var resourceName = assembly
            .GetManifestResourceNames()
            .FirstOrDefault(name => name.EndsWith("pokemon_cards.json", StringComparison.OrdinalIgnoreCase));

        if (resourceName != null)
        {
            return assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Unable to read embedded resource '{resourceName}'.");
        }

        var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "pokemon_cards.json");
        if (File.Exists(filePath))
        {
            return File.OpenRead(filePath);
        }

        throw new FileNotFoundException(
            "pokemon_cards.json not found. Run tools/generate-pokemon-seed.ps1 to generate it.");
    }

    private static Card MapToCard(PokemonCardSeedEntry entry)
    {
        return new Card
        {
            Id = entry.Id,
            Name = entry.Name,
            Attack = entry.Attack,
            Health = entry.Health,
            Cost = entry.Cost,
            Rarity = ParseRarity(entry.Rarity),
            Type = entry.Type ?? "",
            ImageUrl = string.IsNullOrWhiteSpace(entry.ImageUrl)
                ? BuildDefaultImageUrl(entry.Id)
                : entry.ImageUrl
        };
    }

    private static string BuildDefaultImageUrl(int nationalDexId) =>
        $"https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/{nationalDexId:D3}.png";

    private static CardRarity ParseRarity(string rarity) =>
        Enum.TryParse(rarity, true, out CardRarity parsed) ? parsed : CardRarity.Common;
}
