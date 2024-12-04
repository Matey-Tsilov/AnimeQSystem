using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class EndQuizQuestionAnswerFormModel : IMapFrom<BeginQuizQuestionViewModel>
    {
        public string Title { get; set; } = null!;
        public string UserAnswer { get; set; } = null!;
    }
}
