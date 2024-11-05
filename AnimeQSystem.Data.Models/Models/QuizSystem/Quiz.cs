namespace AnimeQSystem.Data.Models.QuizSystem
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    }
}
