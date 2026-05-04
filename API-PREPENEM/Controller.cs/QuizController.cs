using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public QuizController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/quiz — busca todos os quizzes
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var quiz = await _context.Quiz
            .Include(q => q.Assunto)
            .OrderByDescending(q => q.IdQuiz)
            .ToListAsync();

        return Ok(quiz);
    }

    // GET: api/quiz/1 — busca um quiz específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var quiz = await _context.Quiz
            .Include(q => q.Assunto)
            .FirstOrDefaultAsync(q => q.IdQuiz == id);

        if (quiz == null) return NotFound("Quiz não encontrado.");

        return Ok(quiz);
    }

    // POST: api/quiz — cria um novo quiz
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Quiz quiz)
    {
        _context.Quiz.Add(quiz);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = quiz.IdQuiz }, quiz);
    }

    // DELETE: api/quiz/1 — deleta um quiz
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var quiz = await _context.Quiz.FindAsync(id);

        if (quiz == null) return NotFound("Quiz não encontrado.");

        _context.Quiz.Remove(quiz);
        await _context.SaveChangesAsync();

        return NoContent();
    }
} 