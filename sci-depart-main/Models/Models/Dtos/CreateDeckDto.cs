namespace Models.Models.Dtos
{
    public class CreateDeckDto
    {
        public string Name { get; set; } = "";
        public List<int> CardIds { get; set; } = new();
    }
}
