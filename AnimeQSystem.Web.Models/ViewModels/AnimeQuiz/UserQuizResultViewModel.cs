using AnimeQSystem.Web.Models.Enums;

namespace AnimeQSystem.Web.Models.ViewModels.AnimeQuiz
{
    public class UserQuizResultViewModel
    {
        public UserResult UserResult { get; set; }
        public int CorrectAnswers { get; set; }
        public int AllQuestions { get; set; }
        public int Points { get; set; }

    }
}
