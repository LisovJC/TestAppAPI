namespace TestAppAPI.Model
{
    public class Pets
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ushort Age { get; set; } = 0;
    }
}
