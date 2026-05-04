using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriaController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public MateriaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/materia — busca todas as matérias
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materia = await _context.Materias
            .OrderByDescending(m => m.IdMateria)
            .ToListAsync();

        return Ok(materia);
    }

    // GET: api/materia/1 — busca uma matéria específica
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var materia = await _context.Materias
            .FirstOrDefaultAsync(m => m.IdMateria == id);

        if (materia == null) return NotFound("Matéria não encontrada.");

        return Ok(materia);
    }

    // POST: api/materia — cria uma nova matéria
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Materia materia)
    {
        _context.Materias.Add(materia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = materia.IdMateria }, materia);
    }

    // DELETE: api/materia/1 — deleta uma matéria
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var materia = await _context.Materias.FindAsync(id);

        if (materia == null) return NotFound("Matéria não encontrada.");

        _context.Materias.Remove(materia);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
