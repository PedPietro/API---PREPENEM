using Microsoft.EntityFrameworkCore;
using MinhaLojaApi.Models;

namespace MinhaLojaApi.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
     
    }

    public DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("PREPENEM");

        // telaUSUARIO
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Email)
            .HasColumnType("varchar(40)");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Senha)
            .HasColumnType("char(6)");

        modelBuilder.Entity<Usuario>()
            .Property(u => u.FotoPerfil)
            .HasColumnType("varchar(100)");

       

    }
}