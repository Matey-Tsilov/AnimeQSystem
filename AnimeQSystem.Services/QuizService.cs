using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.EntityFrameworkCore;

namespace AnimeQSystem.Services
{
    public class QuizService(IRepository<Quiz, Guid> _quizRepo) : IQuizService
    {
        public async Task<List<QuizCardViewModel>> GetAllQuizzes()
        {
            return await _quizRepo
                .GetAllAttached()
                .To<QuizCardViewModel>()
                .ToListAsync();
        }
    }
}
