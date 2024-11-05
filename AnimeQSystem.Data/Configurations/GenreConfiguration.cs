using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(ModelConstraints.Genre.NameMaxLength)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasMaxLength(ModelConstraints.Genre.DescriptionMaxLength);
        }
    }
}
