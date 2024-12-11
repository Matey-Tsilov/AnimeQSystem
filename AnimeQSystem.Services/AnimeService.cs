using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.ViewModels.Anime;

namespace AnimeQSystem.Services
{
    public class AnimeService(IRepository<Anime, Guid> _animeRepo) : IAnimeService
    {
        public async Task<List<AnimeLongCardViewModel>> GetAllAnimes()
        {
            var allAnimes = await Task.Run(() => _animeRepo.GetAllAttached()
                .To<AnimeLongCardViewModel>()
                .ToList());

            return allAnimes;
        }

        public async Task<AnimeDetailsCardViewModel> GetDetailedAnimeInfo(string animeId)
        {
            if (!Guid.TryParse(animeId, out Guid animeGuid)) throw new InvalidOperationException("There is no such anime");

            Anime? anime = await _animeRepo.GetByIdAsync(animeGuid);
            if (anime is null) throw new InvalidOperationException("There is no such anime");

            return AutoMapperConfig.MapperInstance.Map<AnimeDetailsCardViewModel>(anime);

        }
    }
}
