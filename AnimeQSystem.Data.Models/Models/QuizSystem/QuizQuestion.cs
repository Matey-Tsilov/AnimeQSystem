using AnimeQSystem.Data.Models.Enums;

namespace AnimeQSystem.Data.Models.QuizSystem
{
    public class QuizQuestion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public QuizType QuizType { get; set; }
        public virtual List<QuizOption> QuizOptions { get; set; } = new List<QuizOption>();

        // Navigation Properties
        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; } = null!;
    }
}
