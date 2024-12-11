using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.Anime
{
    public class AnimeDetailsCardViewModel : IMapFrom<Data.Models.AnimeSystem.Anime>, ICustomMapping
    {
        public string AnimePicUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int Episodes { get; set; }
        public int Seasons { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool StillOngoing { get; set; }
        public Rating Rating { get; set; }
        public string Description { get; set; } = null!;

        // Navigation properties
        public Guid WriterId { get; set; }
        public virtual Writer Writer { get; set; } = null!;
        public Guid StudioId { get; set; }
        public virtual Studio Studio { get; set; } = null!;
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
        public virtual List<Character> Characters { get; set; } = new List<Character>();
        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Data.Models.AnimeSystem.Anime, AnimeDetailsCardViewModel>()
                .ForMember(d => d.AnimePicUrl, x => x.MapFrom(src => $"data:image/jpeg;base64,{Convert.ToBase64String(src.AnimePic)}"));
        }
    }
}
