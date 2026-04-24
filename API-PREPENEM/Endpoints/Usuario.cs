using Microsoft.EntityFrameworkCore;
using MinhaLojaApi.Data;
using MinhaLojaApi.Models;

namespace MinhaLojaApi.Endpoints;

public static class UsuarioEndpoints
{
    public static void MapUsuarioEndpoints(this WebApplication app)
    {
        var grupo = app.MapGroup("/usuarios");

        grupo.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Usuario.ToListAsync();
        });

        grupo.MapGet("/{id}", async (int id, AppDbContext db) =>
        {
            var usuario = await db.Usuario.FindAsync(id);

            return usuario is null
                ? Results.NotFound()
                : Results.Ok(usuario);
        });

        grupo.MapPost("/", async (Usuario usuario, AppDbContext db) =>
        {
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();

            return Results.Created($"/usuarios/{usuario.IdUsuario}", usuario);
        });

        grupo.MapPut("/{id}", async (int id, Usuario usuarioAtualizado, AppDbContext db) =>
        {
            var usuario = await db.Usuarios.FindAsync(id);

            if (usuario is null)
                return Results.NotFound();

            usuario.Email = usuarioAtualizado.Email;
            usuario.Senha = usuarioAtualizado.Senha;
            usuario.FotoPerfil = usuarioAtualizado.FotoPerfil;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

 
        grupo.MapDelete("/{id}", async (int id, AppDbContext db) =>
        {
            var usuario = await db.Usuario.FindAsync(id);

            if (usuario is null)
                return Results.NotFound();

            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}