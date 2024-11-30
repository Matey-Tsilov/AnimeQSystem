using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.QuizSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .HasMaxLength(ModelConstraints.QuizQuestion.TitleMaxLength)
                .IsRequired();

            builder.Property(a => a.Answer)
                .IsRequired();

            builder.HasOne(a => a.Quiz)
                .WithMany(a => a.QuizQuestions)
                .HasForeignKey(a => a.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
