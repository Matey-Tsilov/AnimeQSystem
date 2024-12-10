using AnimeQSystem.Services.Mapping;
using AutoMapper;

namespace AnimeQSystem.Web.Models.ViewModels.User
{
    public class LeaderboardUserViewModel : IMapFrom<Data.Models.User>, ICustomMapping
    {
        public int Rank { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Points { get; set; }
        public bool IsDeleted { get; set; }
        public string Country { get; set; } = null!;
        public string ProfilePicBase64 { get; set; } = null!;
        public int UserQuizzesCount { get; set; }

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Data.Models.User, LeaderboardUserViewModel>()
                .ForMember(d => d.Rank, x => x.Ignore());

            expression.CreateMap<Data.Models.User, LeaderboardUserViewModel>()
                .ForMember(d => d.UserQuizzesCount, x => x.MapFrom(src => src.UserQuizzes.Count()));

            expression.CreateMap<Data.Models.User, LeaderboardUserViewModel>()
                .ForMember(d => d.ProfilePicBase64, x => x.MapFrom(src => $"data:image/jpeg;base64,{Convert.ToBase64String(src.ProfilePic)}"));
        }
    }
}
