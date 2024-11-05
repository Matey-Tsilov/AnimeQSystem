using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder
               .HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(ModelConstraints.Studio.NameMaxLength)
                .IsRequired();
        }
    }
}
