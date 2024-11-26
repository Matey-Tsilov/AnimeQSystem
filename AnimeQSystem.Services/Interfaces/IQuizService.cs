using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IQuizService
    {
        Task<List<QuizCardViewModel>> GetAllQuizzes();
    }
}
