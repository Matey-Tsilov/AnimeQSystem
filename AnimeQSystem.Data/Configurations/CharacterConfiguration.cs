using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.AnimeSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.Skill)
                .HasMaxLength(ModelConstraints.Character.SkillMaxLength)
                .IsRequired();

            builder.Property(a => a.Weapon)
                .HasMaxLength(ModelConstraints.Character.WeaponMaxLength);

            builder.Property(a => a.Weakness)
                .HasMaxLength(ModelConstraints.Character.WeaponMaxLength);

            builder.HasOne(a => a.Anime)
                .WithMany(a => a.Characters)
                .HasForeignKey(a => a.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
