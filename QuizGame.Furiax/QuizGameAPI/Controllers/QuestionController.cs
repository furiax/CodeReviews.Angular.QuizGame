using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Data;
using QuizGameAPI.Models;

namespace QuizGameAPI.Controllers
{
    [Route("api/Question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizGameContext _context;
        public QuestionController(QuizGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null) return NotFound();

            return question;
        }

        [HttpPost]
        public async Task<ActionResult<Question>> AddQuestion(QuestionDTO modelDTO)
        {
            if (modelDTO == null) return BadRequest("Question is empty");   
            var quiz = await _context.Quizzes.FindAsync(modelDTO.QuizId);
            if(quiz == null) return BadRequest("Quiz does not exist");

            var question = new Question
            {
                QuestionToAsk = modelDTO.QuestionToAsk,
                CorrectAnswer = modelDTO.CorrectAnswer,
                Option1 = modelDTO.Option1,
                Option2 = modelDTO.Option2,
                Option3 = modelDTO.Option3,
                Option4 = modelDTO.Option4,
                QuizId = modelDTO.QuizId
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditQuestion(Guid id, QuestionDTO modelDTO)
        {
            if (modelDTO == null) return BadRequest("Question cannot be empty");

            var quiz = await _context.Quizzes.FindAsync(modelDTO.QuizId);

            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            question.QuestionToAsk = modelDTO.QuestionToAsk;
            question.CorrectAnswer = modelDTO.CorrectAnswer;
            question.Option1 = modelDTO.Option1;
            question.Option2 = modelDTO.Option2;
            question.Option3 = modelDTO.Option3;
            question.Option4 = modelDTO.Option4;
            question.QuizId = modelDTO.QuizId;
            question.Quiz = quiz;

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Questions.Any(q => q.QuestionId == id))
                    return NotFound();
                else
                    throw new DbUpdateConcurrencyException("Concurrency exception occured");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
