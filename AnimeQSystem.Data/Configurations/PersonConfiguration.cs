using AnimeQSystem.Common;
using AnimeQSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(ModelConstraints.Person.FirstNameMaxLength)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(ModelConstraints.Person.LastNameMaxLength);

            builder.Property(x => x.Age)
                .HasMaxLength(ModelConstraints.Person.AgeMax);

            builder.Property(x => x.HairColor)
                .HasMaxLength(ModelConstraints.Person.HairColorMaxLength);

        }
    }
}
