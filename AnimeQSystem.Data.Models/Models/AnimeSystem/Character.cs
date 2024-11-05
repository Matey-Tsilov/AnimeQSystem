namespace AnimeQSystem.Data.Models.AnimeSystem
{
    public class Character : Person
    {
        public bool IsMainCharacter { get; set; }
        public string Skill { get; set; } = null!;
        public string? Weapon { get; set; }
        public string? Weakness { get; set; }

    }
}
