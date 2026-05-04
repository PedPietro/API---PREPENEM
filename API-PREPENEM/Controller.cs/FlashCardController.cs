using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashCardController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public FlashCardController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/flashcard — busca todos os flashcards
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var flashcard = await _context.FlashCards
            .Include(f => f.Assunto)
            .OrderByDescending(f => f.IdFlashCard)
            .ToListAsync();

        return Ok(flashcard);
    }

    // GET: api/flashcard/1 — busca um flashcard específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var flashcard = await _context.FlashCards
            .Include(f => f.Assunto)
            .FirstOrDefaultAsync(f => f.IdFlashCard == id);

        if (flashcard == null) return NotFound("FlashCard não encontrado.");

        return Ok(flashcard);
    }

    // POST: api/flashcard — cria um novo flashcard
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FlashCard flashcard)
    {
        _context.FlashCards.Add(flashcard);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = flashcard.IdFlashCard }, flashcard);
    }

    // DELETE: api/flashcard/1 — deleta um flashcard
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var flashcard = await _context.FlashCards.FindAsync(id);

        if (flashcard == null) return NotFound("FlashCard não encontrado.");

        _context.FlashCards.Remove(flashcard);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
