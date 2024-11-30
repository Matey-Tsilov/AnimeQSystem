using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static AnimeQSystem.Common.ModelConstraints.Quiz;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class CreateQuizFormModel : IMapTo<Quiz>
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(https?://)?([\w-]+(\.[\w-]+)+)(/[\w- ./?%&=]*)?\.(jpg|jpeg|png|gif|bmp|webp)(\?[\w&=%-]*)?$"
        , ErrorMessage = "Please provide a valid image URL.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int RewardPoints { get; set; }

        public List<QuizQuestionFormModel> QuizQuestions { get; set; } = new List<QuizQuestionFormModel>();
    }
}
