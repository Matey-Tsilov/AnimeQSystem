namespace AnimeQSystem.Data.Models.AnimeSystem
{
    public class Genre
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Anime> Animes { get; set; } = new List<Anime>();
        public virtual List<Writer> Writers { get; set; } = new List<Writer>();
    }
}
