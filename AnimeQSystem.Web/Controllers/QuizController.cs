using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class QuizController(IQuizService _quizService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var list = await _quizService.GetAllQuizzes();

            AllQuizzesViewModel model = new AllQuizzesViewModel()
            {
                AllQuizzes = list
            };

            return View(model);
        }
    }
}
