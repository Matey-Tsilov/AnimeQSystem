using AnimeQSystem.Data.Models.Enums;

namespace AnimeQSystem.Data.Models.AnimeSystem
{
    public class Writer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public string? HairColor { get; set; }
        public virtual List<Anime> AnimesWritten { get; set; } = new List<Anime>();
        public Guid FavoriteGenreId { get; set; }
        public virtual Genre FavoriteGenre { get; set; } = null!;
    }
}
