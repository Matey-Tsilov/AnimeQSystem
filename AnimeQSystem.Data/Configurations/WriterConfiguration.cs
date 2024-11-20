using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(ModelConstraints.Person.FirstNameMaxLength)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(ModelConstraints.Person.LastNameMaxLength);

            builder.Property(x => x.HairColor)
                .HasMaxLength(ModelConstraints.Person.HairColorMaxLength);

            builder.HasOne(x => x.FavoriteGenre)
                .WithMany(x => x.Writers)
                .HasForeignKey(x => x.FavoriteGenreId);
        }
    }
}
