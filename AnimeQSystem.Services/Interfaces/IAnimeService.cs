using AnimeQSystem.Web.Models.ViewModels.Anime;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IAnimeService
    {
        public Task<List<AnimeLongCardViewModel>> GetAllAnimes();
        public Task<AnimeDetailsCardViewModel> GetDetailedAnimeInfo(string animeId);
    }
}
