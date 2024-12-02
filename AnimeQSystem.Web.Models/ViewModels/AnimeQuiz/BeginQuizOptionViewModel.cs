using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    public class BeginQuizOptionViewModel : IMapFrom<QuizOption>, ICustomMapping
    {
        public int QuestionIndex { get; set; }
        public int OptionIndex { get; set; }
        public string OptionText { get; set; } = null!;
        public bool IsChosen { get; set; }

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<QuizOption, BeginQuizOptionViewModel>()
                .ForMember(d => d.IsChosen, x => x.Ignore());

            expression.CreateMap<QuizOption, BeginQuizOptionViewModel>()
                .ForMember(d => d.QuestionIndex, x => x.Ignore());

            expression.CreateMap<QuizOption, BeginQuizOptionViewModel>()
                .ForMember(d => d.OptionIndex, x => x.Ignore());
        }
    }
}
