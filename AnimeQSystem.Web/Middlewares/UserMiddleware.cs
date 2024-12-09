using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.Mix;
using System.Security.Claims;

namespace AnimeQSystem.Web.Middlewares
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var identityUserId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (identityUserId is not null)
                {
                    // Fetch user data
                    var applicationUser = await userService.FindUserByIdentityUserId(identityUserId);
                    if (applicationUser is null)
                    {
                        context.Items["CurrentUser"] = null;
                    }
                    else
                    {
                        UserDetailsVFModel user = AutoMapperConfig.MapperInstance.Map<UserDetailsVFModel>(applicationUser);
                        context.Items["CurrentUser"] = user;
                    }
                }
            }

            await _next(context);
        }
    }
}
