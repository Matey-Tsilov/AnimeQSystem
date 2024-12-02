using AnimeQSystem.Services.Mapping;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    using AnimeQSystem.Data.Models.QuizSystem;
    public class QuizCardViewModel : IMapFrom<Quiz>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int RewardPoints { get; set; }
    }
}
