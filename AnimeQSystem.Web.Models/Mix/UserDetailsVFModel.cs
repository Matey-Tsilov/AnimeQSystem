using AnimeQSystem.Common.CustomAttributes;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Services.Mapping;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static AnimeQSystem.Common.ModelConstraints.User;

namespace AnimeQSystem.Web.Models.Mix
{
    public class UserDetailsVFModel : IMapFrom<Data.Models.User>, IMapTo<Data.Models.User>, ICustomMapping
    {
        public Guid Id { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile? ProfilePicForm { get; set; }

        public byte[]? ProfilePicData { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [MinLength(FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Range(AgeMin, AgeMax)]
        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        [Required]
        public string Country { get; set; } = null!;

        public bool IsSameUser { get; set; } = false;

        public void CreateMappings(IProfileExpression expression)
        {
            expression.CreateMap<Data.Models.User, UserDetailsVFModel>()
                .ForMember(d => d.Email, x => x.MapFrom(src => src.IdentityUser.Email))
                .ForMember(d => d.ProfilePicData, x => x.MapFrom(src => src.ProfilePic));

            expression.CreateMap<UserDetailsVFModel, Data.Models.User>()
                .ForMember(d => d.ProfilePic, x => x.MapFrom(src => src.ProfilePicData));
        }
    }
}