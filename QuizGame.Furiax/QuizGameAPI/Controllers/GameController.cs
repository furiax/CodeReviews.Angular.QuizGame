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
            var games = await _context.Games
                .Include (g => g.Quiz)
                //.ThenInclude(q => q.Questions)
                .ToListAsync();
            return games;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _context.Games
                .Include (g => g.Quiz)
                .FirstOrDefaultAsync(g => g.GameId == id);

            if (game == null) return NotFound();

            return game;
        }


        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(GameDTO modelDTO)
        {
            if (modelDTO == null) return BadRequest("Game is empty");
            var quiz = await _context.Quizzes.FindAsync(modelDTO.QuizId);
            if (quiz == null) return BadRequest("quiz does not excist");

            var game = new Game
            {
                PlayerName = modelDTO.PlayerName,
                Score = modelDTO.Score,
                QuizId = modelDTO.QuizId
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.GameId }, game);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditGame(Guid id, GameDTO modelDTO)
        {
            if (modelDTO == null) return BadRequest("Game cannot be empty");

            var quiz = await _context.Quizzes.FindAsync(modelDTO.QuizId);

            var game = await _context.Games.FindAsync(id);
            if (game == null) return NotFound();

            game.PlayerName = modelDTO.PlayerName;
            game.Score = modelDTO.Score;
            game.QuizId = modelDTO.QuizId;
            game.Quiz = quiz;

            _context.Entry(game).State = EntityState.Modified;

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
