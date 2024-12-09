using AnimeQSystem.Data.Models.Enums;

namespace AnimeQSystem.Web.Models.User
{
    public class UserDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ProfilePictureUrl { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int Height { get; set; }
        public Gender Gender { get; set; }
    }
}