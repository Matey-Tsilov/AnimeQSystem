using AnimeQSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class AnimeController(IAnimeService _animeService) : Controller
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
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string animeId)
        {
            try
            {
                var detailedAnime = await _animeService.GetDetailedAnimeInfo(animeId);

                return View(detailedAnime);
            }
            catch (Exception ex)
            {
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }
    }
}
