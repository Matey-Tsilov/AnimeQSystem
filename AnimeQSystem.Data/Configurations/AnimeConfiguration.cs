using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .HasMaxLength(ModelConstraints.Anime.TitleMaxLength)
                .IsRequired();

            builder.HasOne(a => a.Writer)
                .WithMany(w => w.AnimesWritten)
                .HasForeignKey(a => a.WriterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Studio)
                .WithMany(s => s.Animes)
                .HasForeignKey(a => a.StudioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Genre)
                .WithMany(g => g.Animes)
                .HasForeignKey(a => a.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
