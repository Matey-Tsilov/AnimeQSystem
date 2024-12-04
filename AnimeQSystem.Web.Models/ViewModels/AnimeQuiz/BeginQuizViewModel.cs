using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    public class BeginQuizViewModel : IMapFrom<Quiz>, ICustomMapping
    {
        public Guid QuizId { get; set; }
        public string Title { get; set; } = null!;
        public List<BeginQuizQuestionViewModel> QuizQuestions { get; set; } = new List<BeginQuizQuestionViewModel>();

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Quiz, BeginQuizViewModel>()
                .ForMember(d => d.QuizId, x => x.MapFrom(src => src.Id));
        }
    }
}
