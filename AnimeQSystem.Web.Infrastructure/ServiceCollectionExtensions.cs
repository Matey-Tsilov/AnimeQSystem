using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AnimeQSystem.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services, Assembly assembly)
        {
            Type[] typesToExclude = new Type[] { typeof(IdentityUser) };
            Type[] modelTypes = assembly
                .GetTypes()
                .Where(t =>
                    !t.IsAbstract
                    && !t.IsInterface
                    && !t.IsEnum
                    && !t.Name.EndsWith("attribute"))
                .ToArray();

            foreach (Type type in modelTypes)
            {
                Type repositoryInterface = typeof(IRepository<,>);
                Type repositoryInstance = typeof(BaseRepository<,>);

                if (!typesToExclude.Contains(type))
                {
                    PropertyInfo? idProp = type
                        .GetProperties()
                        .Where(p => p.Name.ToLower() == "id")
                        .SingleOrDefault();

                    Type[] constructArgs = new Type[2];
                    constructArgs[0] = type;
                    if (idProp is null)
                    {
                        // For the mapping tables whose id is complex
                        constructArgs[1] = typeof(object);
                    }
                    else
                    {
                        constructArgs[1] = idProp.PropertyType;
                    }

                    repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
                    repositoryInstance = repositoryInstance.MakeGenericType(constructArgs);

                    services.AddScoped(repositoryInterface, repositoryInstance);
                }
            }

        }
    }
}
