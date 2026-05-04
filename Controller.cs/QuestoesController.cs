using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaLojaApi.Data;
using MinhaLojaApi.Models;

[ApiController]
[Route("api/[controller]")]
public class QuestoesController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public QuestoesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/questoes — busca todas as questões
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questao = await _context.Questoes
            .OrderByDescending(q => q.IdQuestao)
            .ToListAsync();

        return Ok(questao);
    }

    // GET: api/questoes/1 — busca uma questão específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var questao = await _context.Questoes
            .FirstOrDefaultAsync(q => q.IdQuestao == id);

        if (questao == null) return NotFound("Questão não encontrada.");

        return Ok(questao);
    }

    // POST: api/questoes — cria uma nova questao
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Questoes questao)
    {
        _context.Questoes.Add(questao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = questao.IdPost }, questao);
    }

    // DELETE: api/questoes/1 — deleta um questao
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var questao = await _context.Questoes.FindAsync(id);

        if (questao == null) return NotFound("Questão não encontrada.");

        _context.Questoes.Remove(questao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
} 
