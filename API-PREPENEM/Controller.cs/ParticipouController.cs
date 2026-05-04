using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipouController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public ParticipouController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/participou — busca todas as participações
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var participou = await _context.Participou
            .Include(p => p.Usuario)
            .Include(p => p.Maratona)
            .OrderByDescending(p => p.IdParticipacao)
            .ToListAsync();

        return Ok(participou);
    }

    // GET: api/participou/1 — busca uma participação específica
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var participou = await _context.Participou
            .Include(p => p.Usuario)
            .Include(p => p.Maratona)
            .FirstOrDefaultAsync(p => p.IdParticipacao == id);

        if (participou == null) return NotFound("Participação não encontrada.");

        return Ok(participou);
    }

    // POST: api/participou — cria uma nova participação
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Participou participou)
    {
        _context.Participou.Add(participou);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = participou.IdParticipacao }, participou);
    }

    // DELETE: api/participou/1 — deleta uma participação
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var participou = await _context.Participou.FindAsync(id);

        if (participou == null) return NotFound("Participação não encontrada.");

        _context.Participou.Remove(participou);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
