using AnimeQSystem.Data.Models.Enums;

namespace AnimeQSystem.Data.Models.AnimeSystem
{
    public class Character
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public string? HairColor { get; set; }
        public bool IsMainCharacter { get; set; }
        public string Skill { get; set; } = null!;
        public string? Weapon { get; set; }
        public string? Weakness { get; set; }

        // navigation properties
        public Guid AnimeId { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
