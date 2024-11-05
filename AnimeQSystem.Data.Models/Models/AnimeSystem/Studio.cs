namespace AnimeQSystem.Data.Models.AnimeSystem
{
    public class Studio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime DateFounded { get; set; }
        public virtual List<Anime> Animes { get; set; } = new List<Anime>();
    }
}
