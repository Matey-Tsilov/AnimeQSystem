using AutoMapper;
using System.Reflection;

namespace AnimeQSystem.Services.AutoMapper
{
    public class AutoMapperConfig
    {
        private static bool initialized;

        public static IMapper MapperInstance { get; set; } = null!;

        public static void RegisterMappings(params Assembly[] assemblies)
        {
            if (initialized)
            {
                return;
            }

            initialized = true;

            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToList();

            var config = new MapperConfigurationExpression();
            config.CreateProfile(
                "ReflectionProfile",
                configuration =>
                {
                    // IMapFrom<>
                    foreach (var map in GetFromMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    // IMapTo<>
                    foreach (var map in GetToMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    // IHaveCustomMappings
                    foreach (var map in GetCustomMappings(types))
                    {
                        map.CreateMappings(configuration);
                    }
                });

            MapperInstance = new Mapper(new MapperConfiguration(config));
        }

        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            // Get all mentions that implement the IMapFrom interface
            var fromMaps = from t in types
                           from i in t.GetTypeInfo().GetInterfaces()
                           where i.GetTypeInfo().IsGenericType &&
                                 i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                 !t.GetTypeInfo().IsAbstract &&
                                 !t.GetTypeInfo().IsInterface
                           select new TypesMap
                           {
                               // The source is the generic type of the IMapFrom interface
                               Source = i.GetTypeInfo().GetGenericArguments()[0],
                               Destination = t,
                           };

            return fromMaps;
        }

        private static IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
        {
            // Get all mentions that implement the IMapTo interface
            var toMaps = from t in types
                         from i in t.GetTypeInfo().GetInterfaces()
                         where i.GetTypeInfo().IsGenericType &&
                               i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.GetTypeInfo().IsAbstract &&
                               !t.GetTypeInfo().IsInterface
                         select new TypesMap
                         {
                             // The source is the extension type of the IMapTo interface
                             Source = t,
                             Destination = i.GetTypeInfo().GetGenericArguments()[0],
                         };

            return toMaps;
        }

        private static IEnumerable<ICustomMapping> GetCustomMappings(IEnumerable<Type> types)
        {
            // Get all mentions that implement the ICustomMapping interface
            var customMaps = from t in types
                             from i in t.GetTypeInfo().GetInterfaces()
                             where typeof(ICustomMapping).GetTypeInfo().IsAssignableFrom(t) &&
                                   !t.GetTypeInfo().IsAbstract &&
                                   !t.GetTypeInfo().IsInterface
                             select (ICustomMapping)Activator.CreateInstance(t);

            // Return all custom mappings after calling the CreateCustomMapping method we implement with custom expressions
            return customMaps;
        }

        private class TypesMap
        {
            public Type Source { get; set; }

            public Type Destination { get; set; }
        }
    }
}
