using AniQu.Models.Enums;

namespace AniQu.Models.Interfaces
{
    public interface IPerson
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public int? Height { get; set; }
        public string? HairColor { get; set; }
    }
}
