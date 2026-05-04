using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public PostController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/post — busca todos os posts
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _context.Posts
            .Include(p => p.Usuario)  // traz os dados do usuário junto
            .OrderByDescending(p => p.DataCriacao)
            .ToListAsync();

        return Ok(posts);
    }

    // GET: api/post/1 — busca um post específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _context.Posts
            .Include(p => p.Usuario)
            .FirstOrDefaultAsync(p => p.IdPost == id);

        if (post == null) return NotFound("Post não encontrado.");

        return Ok(post);
    }

    // POST: api/post — cria um novo post
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Post post)
    {
        post.DataCriacao = DateTime.UtcNow;

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = post.IdPost }, post);
    }

    // DELETE: api/post/1 — deleta um post
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null) return NotFound("Post não encontrado.");

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }
} 

/*

PREECISA CRIAR A MIGRAÇÃO E ATUALIZAR O BANCO DE DADOS APÓS ESSAS ALTERAÇÕES:

cd API-PREPENEM
dotnet ef migrations add CriacaoInicial
dotnet ef database update
*/