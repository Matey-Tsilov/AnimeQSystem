using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using AutoMapper;

namespace AnimeQSystem.Web.Models.FormModels.AnimeQuiz
{
    public class EndQuizFormModel : IMapFrom<BeginQuizViewModel>, ICustomMapping
    {
        public Guid QuizId { get; set; }

        public List<EndQuizQuestionAnswerFormModel> UserAnswers { get; set; } = new List<EndQuizQuestionAnswerFormModel>();

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<BeginQuizViewModel, EndQuizFormModel>()
                .ForMember(d => d.UserAnswers, x => x.MapFrom(src => src.QuizQuestions));
        }
    }
}
