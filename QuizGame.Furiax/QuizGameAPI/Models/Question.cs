using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizGameAPI.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }
        [Required]
        public string QuestionToAsk { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        public string? Option1 {get; set;}
        public string? Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set;}

        [ForeignKey("QuizId")]
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
