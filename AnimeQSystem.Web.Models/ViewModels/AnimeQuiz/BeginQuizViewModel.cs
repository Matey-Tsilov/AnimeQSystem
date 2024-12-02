using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    public class BeginQuizViewModel : IMapFrom<Quiz>
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int RewardPoints { get; set; }
        public List<BeginQuizQuestionViewModel> QuizQuestions { get; set; } = new List<BeginQuizQuestionViewModel>();
    }
}
