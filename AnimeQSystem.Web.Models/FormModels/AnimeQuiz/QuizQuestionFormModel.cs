using AnimeQSystem.Common;
using System.ComponentModel.DataAnnotations;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class QuizQuestionFormModel
    {
        [Required]
        [MinLength(ModelConstraints.QuizQuestion.TitleMinLength)]
        [MaxLength(ModelConstraints.QuizQuestion.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MinLength(ModelConstraints.QuizQuestion.AnswerMinLength)]
        public string? Answer { get; set; }

        [Required]
        public int QuizType { get; set; }

        public virtual List<QuizOptionFormModel> QuizOptions { get; set; } = new List<QuizOptionFormModel>();
    }
}