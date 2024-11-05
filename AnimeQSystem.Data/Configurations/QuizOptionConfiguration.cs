using AnimeQSystem.Common;
using AnimeQSystem.Data.Models.QuizSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class QuizOptionConfiguration : IEntityTypeConfiguration<QuizOption>
    {
        public void Configure(EntityTypeBuilder<QuizOption> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder.Property(a => a.OptionText)
                .HasMaxLength(ModelConstraints.QuizOption.OptionTextMaxLength);

            builder.HasOne(a => a.QuizQuestion)
                .WithMany(a => a.QuizOptions)
                .HasForeignKey(a => a.QuizQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
