using AutoMapper;

namespace AnimeQSystem.Services.AutoMapper
{
    public interface ICustomMapping
    {
        public void CreateMappings(IProfileExpression expression);
    }
}
