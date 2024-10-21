using AniQu.Models.Enums;

namespace AniQu.Models.AnimeSystem
{
    public class Anime
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public int Episodes { get; set; }
        public int Seasons { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool StillOngoing { get; set; }
        public Rating Rating { get; set; }

        // Navigation properties
        public Guid WriterId { get; set; }
        public virtual Writer Writer { get; set; } = null!;
        public Guid StudioId { get; set; }
        public virtual Studio Studio { get; set; } = null!;
        public Guid MainCharacterId { get; set; }
        public virtual Character MainCharacter { get; set; } = null!;
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
    }
}
