namespace AniQu.Models.AnimeSystem
{
    public class Genre
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public string? AgeRestriction { get; set; }
    }
}
