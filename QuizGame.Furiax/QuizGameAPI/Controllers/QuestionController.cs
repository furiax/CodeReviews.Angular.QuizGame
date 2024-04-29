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
        public async Task<ActionResult<Question>> AddQuestion(Question model)
        {
            _context.Questions.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = model.QuizId }, model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditQuestion(Guid id, Question model)
        {
            if (id != model.QuestionId)
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
