using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssuntoController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public AssuntoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/assunto — busca todos os assuntos
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assunto = await _context.Assuntos
            .Include(a => a.Materia)
            .OrderByDescending(a => a.IdAssunto)
            .ToListAsync();

        return Ok(assunto);
    }

    // GET: api/assunto/1 — busca um assunto específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var assunto = await _context.Assuntos
            .Include(a => a.Materia)
            .FirstOrDefaultAsync(a => a.IdAssunto == id);

        if (assunto == null) return NotFound("Assunto não encontrado.");

        return Ok(assunto);
    }

    // POST: api/assunto — cria um novo assunto
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Assunto assunto)
    {
        _context.Assuntos.Add(assunto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = assunto.IdAssunto }, assunto);
    }

    // DELETE: api/assunto/1 — deleta um assunto
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var assunto = await _context.Assuntos.FindAsync(id);

        if (assunto == null) return NotFound("Assunto não encontrado.");

        _context.Assuntos.Remove(assunto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
