using Microsoft.EntityFrameworkCore;
using MinhaLojaApi.Models;
namespace MinhaLojaApi.Data;
// Cria a classe de contexto que herda das funções do Entity Framework (DbContext)
//classe nativa do Entity Framework. É a classe DbContext que tem o poder de abrir
//conexões, fazer consultas (SELECT) e salvar dados (INSERT, UPDATE, DELETE) no banco.
public class AppDbContext : DbContext
    {
    // Construtor que recebe as configurações de banco e passa para a classe base
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }
    public DbSet<FlashCard> FlashCards { get; set; }
    public DbSet<Maratona> Maratonas { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Participou> Participou { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Questoes> Questoes { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Pontuacao> Pontuacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.HasDefaultSchema("PREPENEM");

    // Usuario
    modelBuilder.Entity<Usuario>()
        .Property(u => u.Email)
        .IsRequired()
        .HasColumnType("varchar(100)");

    modelBuilder.Entity<Usuario>()
        .Property(u => u.Senha)
        .IsRequired()
        .HasColumnType("varchar(100)");

    // Maratona
    modelBuilder.Entity<Maratona>()
        .Property(m => m.Titulo)
        .IsRequired()
        .HasColumnType("varchar(100)");

    modelBuilder.Entity<Maratona>()
        .Property(m => m.TipoDeMaratona)
        .HasColumnType("varchar(50)");

    // Participou — chave composta se não tiver IdParticipacao
    modelBuilder.Entity<Participou>()
        .HasOne(p => p.Usuario)
        .WithMany()
        .HasForeignKey(p => p.IdUsuario);

    modelBuilder.Entity<Participou>()
        .HasOne(p => p.Maratona)
        .WithMany()
        .HasForeignKey(p => p.IdMaratona);

    // Quiz
    modelBuilder.Entity<Quiz>()
        .Property(q => q.Enunciado)
        .IsRequired()
        .HasColumnType("varchar(500)");

    modelBuilder.Entity<Quiz>()
        .HasOne(q => q.Assunto)
        .WithMany()
        .HasForeignKey(q => q.IdAssunto);

    // Flashcard
    modelBuilder.Entity<FlashCard>()
        .Property(f => f.Pergunta)
        .IsRequired()
        .HasColumnType("varchar(300)");

    modelBuilder.Entity<FlashCard>()
        .HasOne(f => f.Assunto)
        .WithMany()
        .HasForeignKey(f => f.IdTopico);    

    // Assunto
    modelBuilder.Entity<Assunto>()
        .HasOne(a => a.Materia)
        .WithMany()
        .HasForeignKey(a => a.IdMateria);
        
}
    
}
