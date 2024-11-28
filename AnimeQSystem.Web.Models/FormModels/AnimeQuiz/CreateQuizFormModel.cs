using System.ComponentModel.DataAnnotations;
using static AnimeQSystem.Common.ModelConstraints;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class CreateQuizFormModel
    {
        [Required]
        [MinLength(Quiz.TitleMinLength)]
        [MaxLength(Quiz.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(Quiz.DescriptionMinLength)]
        [MaxLength(Quiz.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^(https?://)?([\w-]+(\.[\w-]+)+)(/[\w- ./?%&=]*)?\.(jpg|jpeg|png|gif|bmp|webp)$"
        , ErrorMessage = "Please provide a valid image URL.")]
        public string ImageUrl { get; set; }

        [Required]
        public int RewardPoints { get; set; }
    }
}
