using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Models;

namespace QuizGameAPI.Data
{
    public class QuizGameContext : DbContext
    {
        public QuizGameContext(DbContextOptions<QuizGameContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Quiz)
                .WithMany(qz => qz.Games)
                .HasForeignKey(g => g.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { QuizId = Guid.Parse("409aa05a-de77-470b-929b-10b250cdffa4"), QuizName = "General Knowledge" },
                new Quiz { QuizId = Guid.Parse("0cd38b82-8078-4d71-912d-c224ce52d5e5"), QuizName = "Football"}
                );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionToAsk = "What is the capital of Belgium?",
                    QuizId = Guid.Parse("409aa05a-de77-470b-929b-10b250cdffa4"),
                    CorrectAnswer = "Brussels",
                    Option1 = "Antwerp",
                    Option2 = "Ghent",
                    Option3 = "Brussels",
                    Option4 = "Brugge"
                },
                new Question
                {
                    QuestionToAsk = "Who won WK2022 in Qatar ?",
                    QuizId = Guid.Parse("0cd38b82-8078-4d71-912d-c224ce52d5e5"),
                    CorrectAnswer = "Argentina",
                    Option1 = "Argentina",
                    Option2 = "Croatia",
                    Option3 = "France",
                    Option4 = "Marocco"
                }
                );

        }
    }
}
