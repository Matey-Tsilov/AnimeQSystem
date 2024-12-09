using AnimeQSystem.Common;
using AnimeQSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.FirstName)
                .HasMaxLength(ModelConstraints.User.FirstNameMaxLength)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(ModelConstraints.User.LastNameMaxLength)
                .IsRequired();

            builder.Property(a => a.Age)
                .HasMaxLength(ModelConstraints.User.AgeMax);

            builder.Property(a => a.Country)
                .IsRequired();

            // One-to-One relationship between IdentityUser (AspNetUsers) and AppUser
            builder.HasOne(a => a.IdentityUser)  // User has one IdentityUser
                .WithOne()  // IdentityUser has one User
                .HasForeignKey<User>(a => a.IdentityUserId)  // User.IdentityUserId will be the foreign key
                .IsRequired();  // This ensures the relationship is required
        }
    }
}
