namespace AniQu.Models
{
    public class AppUser : Person
    {
        public int Points { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public string Country { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
