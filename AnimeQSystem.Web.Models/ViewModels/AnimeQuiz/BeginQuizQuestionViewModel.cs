using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    public class BeginQuizQuestionViewModel : IMapFrom<QuizQuestion>, ICustomMapping
    {
        public int Index { get; set; }
        public string Title { get; set; } = null!;
        public string YourAnswer { get; set; } = null!;
        public QuizType QuizType { get; set; }
        public virtual List<BeginQuizOptionViewModel> QuizOptions { get; set; } = new List<BeginQuizOptionViewModel>();

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<QuizQuestion, BeginQuizQuestionViewModel>()
                .ForMember(d => d.YourAnswer, x => x.Ignore());

            expression.CreateMap<QuizQuestion, BeginQuizQuestionViewModel>()
                .ForMember(d => d.Index, x => x.Ignore());
        }
    }
}
