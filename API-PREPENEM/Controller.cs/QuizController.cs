using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Data;
using APIPREPENEM.Models;

namespace APIPREPENEM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase //define aqui a rota 
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco
    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/usuarios — busca todos os usuários
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuario = await _context.Usuario
            .OrderByDescending(u => u.IdUsuario)
            .ToListAsync();

        return Ok(usuario);
    }

    // GET: api/usuarios/1 — busca um usuário específico
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _context.Usuario
            .FirstOrDefaultAsync(u => u.IdUsuario == id);

        if (usuario == null) return NotFound("Usuário não encontrado.");

        return Ok(usuario);
    }

    // POST: api/usuarios — cria um novo usuario
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsuario }, usuario);
    }

    // DELETE: api/usuarios/1 — deleta um usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _context.Usuario.FindAsync(id);

        if (usuario == null) return NotFound("Usuário não encontrado.");

        _context.Usuario.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }
} 