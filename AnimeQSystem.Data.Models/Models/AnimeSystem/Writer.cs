namespace AniQu.Models.AnimeSystem
{
    public class Writer : Person
    {
        public List<Anime> AnimesWritten { get; set; } = new List<Anime>();
        public Guid FavoriteGenreId { get; set; }
        public virtual Genre FavoriteGenre { get; set; } = null!;
    }
}
