using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.QuizSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(ModelConstraints.Quiz.TitleMaxLength)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(ModelConstraints.Quiz.DescriptionMaxLength)
                .IsRequired();

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.UserCreatedQuizzes)
                .HasForeignKey(x => x.CreatorId);

            builder.Property(x => x.Image)
                .IsRequired();

            builder.Property(x => x.RewardPoints)
                .IsRequired();

        }
    }
}
