﻿namespace AnimeQSystem.Data.Models.QuizSystem
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual List<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    }
}
