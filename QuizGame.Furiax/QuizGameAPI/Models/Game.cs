using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizGameAPI.Models
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public int Score { get; set; } = 0;
        [ForeignKey("QuizId")]
        public Guid QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }

    public class GameDTO
    {
        public int Score { get; set; }
        public Guid QuizId { get; set; }
    }
}
