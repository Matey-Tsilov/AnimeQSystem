using System.ComponentModel.DataAnnotations;
using static AnimeQSystem.Common.ModelConstraints;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class CreateQuizFormModel
    {
        [Required]
        [MinLength(Quiz.TitleMinLength)]
        [MaxLength(Quiz.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(Quiz.DescriptionMinLength)]
        [MaxLength(Quiz.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(https?://)?([\w-]+(\.[\w-]+)+)(/[\w- ./?%&=]*)?\.(jpg|jpeg|png|gif|bmp|webp)$"
        , ErrorMessage = "Please provide a valid image URL.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int RewardPoints { get; set; }

        public List<QuizQuestionFormModel> QuizQuestions { get; set; } = new List<QuizQuestionFormModel>();
    }
}
