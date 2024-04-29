using System.ComponentModel.DataAnnotations;

namespace QuizGameAPI.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizId { get; set; }
        [Required]
        public string QuizName { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
