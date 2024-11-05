using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasOne(x => x.FavoriteGenre)
                .WithMany(x => x.Writers)
                .HasForeignKey(x => x.FavoriteGenreId);
        }
    }
}
