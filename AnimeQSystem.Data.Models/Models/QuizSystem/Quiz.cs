using AnimeQSystem.Data.Models.Models;

namespace AnimeQSystem.Data.Models.QuizSystem
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public byte[] Image { get; set; } = null!;
        public int RewardPoints { get; set; }

        // Navigation properties
        public Guid CreatorId { get; set; }
        public virtual User Creator { get; set; } = null!;
        public virtual List<QuizzesUsers> QuizUsers { get; set; } = new List<QuizzesUsers>();
        public virtual List<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    }
}
