using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.Anime
{
    public class AnimeLongCardViewModel : IMapFrom<Data.Models.AnimeSystem.Anime>, ICustomMapping
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string AnimePicUrl { get; set; } = null!;
        public Rating Rating { get; set; }
        public string Description { get; set; } = null!;
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Data.Models.AnimeSystem.Anime, AnimeLongCardViewModel>()
                .ForMember(d => d.AnimePicUrl, x => x.MapFrom(src => $"data:image/jpeg;base64,{Convert.ToBase64String(src.AnimePic)}"));
        }
    }
}
