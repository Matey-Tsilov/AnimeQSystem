using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static AnimeQSystem.Common.ModelConstraints.QuizOption;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class QuizOptionFormModel : IMapTo<QuizOption>
    {
        [MinLength(OptionTextMinLength)]
        [MaxLength(OptionTextMaxLength)]
        public string OptionText { get; set; } = null!;

        [Required(ErrorMessage = "At least one true option must be selected")]
        public bool IsCorrect { get; set; } = false;
    }
}