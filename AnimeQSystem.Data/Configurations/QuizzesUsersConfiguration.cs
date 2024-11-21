using AnimeQSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeQSystem.Data.Configurations
{
    public class QuizzesUsersConfiguration : IEntityTypeConfiguration<QuizzesUsers>
    {
        public void Configure(EntityTypeBuilder<QuizzesUsers> builder)
        {
            builder.HasKey(qu => new { qu.UserId, qu.QuizId });

            // Configure the relationship between User and Quiz via the QuizUser table

            // We can check what kind of UserQuizzes were taken by this user
            builder.HasOne(qu => qu.User) // A QuizUser has one User
                .WithMany(u => u.UserQuizzes) // A User can have many Quizzes taken
                .HasForeignKey(qu => qu.UserId) // Foreign key for User in the QuizUser table
                .OnDelete(DeleteBehavior.NoAction);

            // We can check what kind of QuizUsers have taken this quiz
            builder.HasOne(qu => qu.Quiz) // A QuizUser has one Quiz
                .WithMany(q => q.QuizUsers) // A Quiz can be taken by many Users
                .HasForeignKey(qu => qu.QuizId); // Foreign key for Quiz in the QuizUser table
        }
    }
}
