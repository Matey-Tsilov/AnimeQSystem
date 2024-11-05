using AnimeQSystem.Common;
using AnimeQSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(a => a.FirstName)
                .HasMaxLength(ModelConstraints.AppUser.FirstNameMaxLength)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(ModelConstraints.AppUser.LastNameMaxLength)
                .IsRequired();

            builder.Property(a => a.Age)
                .HasMaxLength(ModelConstraints.AppUser.AgeMax);

            builder.Property(a => a.Country)
                .HasMaxLength(ModelConstraints.AppUser.CountryMaxLength)
                .IsRequired();
        }
    }
}
