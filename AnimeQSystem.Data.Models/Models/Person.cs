using AniQu.Models.Enums;
using AniQu.Models.Interfaces;

namespace AniQu.Models
{
    public class Person : IPerson
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
