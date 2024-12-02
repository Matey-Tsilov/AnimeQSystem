using AnimeQSystem.Web.Models.FormModels.AnimeQuiz;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using System.Security.Claims;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizCardViewModel>> GetAllQuizzes();
        Task<bool> CreateQuiz(CreateQuizFormModel modal, ClaimsPrincipal user);
        Task<BeginQuizViewModel> CreateBeginQuizViewModel(Guid quizId);
    }
}
