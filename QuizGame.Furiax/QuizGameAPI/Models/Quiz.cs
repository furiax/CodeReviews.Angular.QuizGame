using System.ComponentModel.DataAnnotations;

namespace QuizGameAPI.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizId { get; set; } = Guid.NewGuid();
        [Required]
        public string QuizName { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
