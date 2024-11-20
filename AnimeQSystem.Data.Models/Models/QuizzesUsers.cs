using AnimeQSystem.Data.Models.QuizSystem;

namespace AnimeQSystem.Data.Models.Models
{
    public class QuizzesUsers
    {
        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; } = null!;
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

    }
}
