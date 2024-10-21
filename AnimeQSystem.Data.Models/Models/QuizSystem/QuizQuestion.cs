using AniQu.Models.Enums;

namespace AniQu.Models.QuizSystem
{
    public class QuizQuestion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public QuizType QuizType { get; set; }
        public List<QuizOption> QuizOptions { get; set; } = new List<QuizOption>();

        // Navigation Properties
        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; } = null!;
    }
}
