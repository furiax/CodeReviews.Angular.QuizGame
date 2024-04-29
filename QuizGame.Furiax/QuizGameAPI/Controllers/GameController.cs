using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Data;
using QuizGameAPI.Models;

namespace QuizGameAPI.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly QuizGameContext _context;
        public GameController(QuizGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null) return NotFound();

            return game;
        }


        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game model)
        {
            _context.Games.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = model.GameId }, model);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditGame(Guid id, Game model)
        {
            if (id != model.GameId)
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
                if (_context.Games.Any(q => q.GameId == id))
                    return NotFound();
                else
                    throw new DbUpdateConcurrencyException("Concurrency exception occured");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return NotFound();

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
