using AnimeQSystem.Common;
using System.ComponentModel.DataAnnotations;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class QuizOptionFormModel
    {
        [MinLength(ModelConstraints.QuizOption.OptionTextMinLength)]
        [MaxLength(ModelConstraints.QuizOption.OptionTextMaxLength)]
        public string? OptionText { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}