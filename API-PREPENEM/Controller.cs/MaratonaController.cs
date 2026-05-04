using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaratonaController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public MaratonaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/maratona — busca todas as maratonas
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var maratona = await _context.Maratonas
            .OrderByDescending(m => m.IdMaratona)
            .ToListAsync();

        return Ok(maratona);
    }

    // GET: api/maratona/1 — busca uma maratona específica
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var maratona = await _context.Maratonas
            .FirstOrDefaultAsync(m => m.IdMaratona == id);

        if (maratona == null) return NotFound("Maratona não encontrada.");

        return Ok(maratona);
    }

    // POST: api/maratona — cria uma nova maratona
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Maratona maratona)
    {
        _context.Maratonas.Add(maratona);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = maratona.IdMaratona }, maratona);
    }

    // DELETE: api/maratona/1 — deleta uma maratona
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var maratona = await _context.Maratonas.FindAsync(id);

        if (maratona == null) return NotFound("Maratona não encontrada.");

        _context.Maratonas.Remove(maratona);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
