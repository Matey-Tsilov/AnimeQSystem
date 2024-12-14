using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static AnimeQSystem.Common.ModelConstraints.QuizQuestion;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class QuizQuestionFormModel : IMapTo<QuizQuestion>
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public int Index { get; set; }

        [MinLength(AnswerMinLength)]
        public string Answer { get; set; } = null!;

        [Required]
        public int QuizType { get; set; }

        public virtual List<QuizOptionFormModel> QuizOptions { get; set; } = new List<QuizOptionFormModel>();
    }
}