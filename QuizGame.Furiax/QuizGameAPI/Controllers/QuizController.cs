using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Data;
using QuizGameAPI.Models;

namespace QuizGameAPI.Controllers
{
    [Route("api/Quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizGameContext _context;
        public QuizController(QuizGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizes()
        {
            return await _context.Quizzes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(Guid id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);

            if (quiz == null) return NotFound();

            return quiz;
        }

        [HttpPost]
        public async Task<ActionResult<Quiz>> AddQuiz(Quiz model)
        {
            _context.Quizzes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = model.QuizId }, model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditQuiz(Guid id, Quiz model)
        {
            if (id != model.QuizId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Quizzes.Any(q => q.QuizId == id))
                    return NotFound();
                else
                    throw new DbUpdateConcurrencyException("Concurrency exception occured");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null) return NotFound();

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
