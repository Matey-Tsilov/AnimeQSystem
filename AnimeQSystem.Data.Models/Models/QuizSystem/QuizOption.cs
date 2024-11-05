namespace AnimeQSystem.Data.Models.QuizSystem
{
    public class QuizOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? OptionText { get; set; }
        public bool IsCorrect { get; set; }

        // Navigation Properties
        public Guid QuizQuestionId { get; set; }
        public virtual QuizQuestion QuizQuestion { get; set; } = null!;
    }
}
