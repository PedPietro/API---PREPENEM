using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontuacaoController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public PontuacaoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/pontuacao — busca todas as pontuações
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pontuacao = await _context.Pontuacoes
            .OrderByDescending(p => p.IdPontuacao)
            .ToListAsync();

        return Ok(pontuacao);
    }

    // GET: api/pontuacao/1 — busca uma pontuação específica
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pontuacao = await _context.Pontuacoes
            .FirstOrDefaultAsync(p => p.IdPontuacao == id);

        if (pontuacao == null) return NotFound("Pontuação não encontrada.");

        return Ok(pontuacao);
    }

    // POST: api/pontuacao — cria uma nova pontuação
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pontuacao pontuacao)
    {
        _context.Pontuacoes.Add(pontuacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = pontuacao.IdPontuacao }, pontuacao);
    }

    // DELETE: api/pontuacao/1 — deleta uma pontuação
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pontuacao = await _context.Pontuacoes.FindAsync(id);

        if (pontuacao == null) return NotFound("Pontuação não encontrada.");

        _context.Pontuacoes.Remove(pontuacao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
