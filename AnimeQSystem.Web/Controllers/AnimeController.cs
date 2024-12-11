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
            var allAnimes = await _animeService.GetAllAnimes();

            return View(allAnimes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string animeId)
        {
            var detailedAnime = await _animeService.GetDetailedAnimeInfo(animeId);

            return View(detailedAnime);
        }
    }
}
