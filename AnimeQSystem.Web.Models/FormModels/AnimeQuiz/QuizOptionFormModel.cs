using AnimeQSystem.Common;
using System.ComponentModel.DataAnnotations;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class QuizOptionFormModel
    {
        [MinLength(ModelConstraints.QuizOption.OptionTextMinLength)]
        [MaxLength(ModelConstraints.QuizOption.OptionTextMaxLength)]
        public string? OptionText { get; set; }

        [Required(ErrorMessage = "At least one true option must be selected")]
        public bool IsCorrect { get; set; } = false;
    }
}