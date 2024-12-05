using AnimeQSystem.Services.Mapping;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    using AnimeQSystem.Data.Models.Models;
    using AnimeQSystem.Data.Models.QuizSystem;
    using AutoMapper;

    public class QuizCardViewModel : IMapFrom<Quiz>, ICustomMapping
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid CreatorId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int RewardPoints { get; set; }
        public virtual List<QuizzesUsers> QuizUsers { get; set; } = new List<QuizzesUsers>();

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Quiz, QuizCardViewModel>()
                .ForMember(d => d.ImageUrl, x => x.MapFrom(src => $"data:image/jpeg;base64,{Convert.ToBase64String(src.Image)}"));
        }
    }
}
