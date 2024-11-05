using AnimeQSystem.Data.Models.Enums;

namespace AnimeQSystem.Data.Models
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public string? HairColor { get; set; }
    }
}
