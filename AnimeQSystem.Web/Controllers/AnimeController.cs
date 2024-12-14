using AnimeQSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;

namespace AnimeQSystem.Web.Controllers
{
    public class AnimeController(IAnimeService _animeService, ILogger<AnimeController> _logger) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var allAnimes = await _animeService.GetAllAnimes();

                return View(allAnimes);
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't open all animes dashboard" + ex.Message);
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string animeId)
        {
            try
            {
                string animeIdSafe = Sanitizer.GetSafeHtmlFragment(animeId);
                var detailedAnime = await _animeService.GetDetailedAnimeInfo(animeIdSafe);

                return View(detailedAnime);
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't check the details of a specific anime" + ex.Message);
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }
    }
}
