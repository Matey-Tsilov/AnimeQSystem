using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.FormModels.AnimeQuiz;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class QuizController(IQuizService _quizService) : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }
        public async Task<IActionResult> All()
        {
            var list = await _quizService.GetAllQuizzes();

            AllQuizzesViewModel model = new AllQuizzesViewModel()
            {
                AllQuizzes = list
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuizFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await _quizService.CreateQuiz(formModel, User);

            return RedirectToAction(nameof(Index));
        }
    }
}
