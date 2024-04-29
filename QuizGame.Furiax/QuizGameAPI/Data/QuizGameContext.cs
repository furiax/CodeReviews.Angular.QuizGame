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

        }
    }
}
