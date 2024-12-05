using AnimeQSystem.Common.CustomAttributes;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;

using Microsoft.AspNetCore.Http;
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
        [MaxFileSize(5 * 1024 * 1024)] //5MB
        public IFormFile ImageFile { get; set; } = null!;

        // This is for post-processing purposes
        public byte[]? Image { get; set; }

        [Required]
        public int RewardPoints { get; set; }

        public List<QuizQuestionFormModel> QuizQuestions { get; set; } = new List<QuizQuestionFormModel>();
    }
}
