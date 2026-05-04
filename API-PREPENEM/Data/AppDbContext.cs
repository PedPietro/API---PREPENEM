using Microsoft.EntityFrameworkCore;
using APIPREPENEM.Models;

namespace APIPREPENEM.Data;

// Cria a classe de contexto que herda das funções do Entity Framework (DbContext)
//classe nativa do Entity Framework. É a classe DbContext que tem o poder de abrir
//conexões, fazer consultas (SELECT) e salvar dados (INSERT, UPDATE, DELETE) no banco.
public class AppDbContext : DbContext
{
    // Construtor que recebe as configurações de banco e passa para a classe base
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuario { get; set; } = null!;
    public DbSet<Assunto> Assuntos { get; set; } = null!;
    public DbSet<FlashCard> FlashCards { get; set; } = null!;
    public DbSet<Maratona> Maratonas { get; set; } = null!;
    public DbSet<Materia> Materias { get; set; } = null!;
    public DbSet<Participou> Participou { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Questoes> Questoes { get; set; } = null!;
    public DbSet<Quiz> Quiz { get; set; } = null!;
    public DbSet<Pontuacao> Pontuacoes { get; set; } = null!;

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
            .HasColumnType("varchar(MAX)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Explicacao)
            .IsRequired()
            .HasColumnType("varchar(MAX)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Alt_a)
            .IsRequired()
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Alt_b)
            .IsRequired()
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Alt_c)
            .IsRequired()
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Alt_d)
            .IsRequired()
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.Alt_e)
            .IsRequired()
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Quiz>()
            .Property(q => q.RespostaCorreta)
            .IsRequired()
            .HasColumnType("char(1)");

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
            .Property(f => f.Resposta)
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

        //Post 
        modelBuilder.Entity<Post>()
            .HasOne(po => po.Usuario)
            .WithMany()
            .HasForeignKey(po => po.IdUsuario);

        //Questoes
        modelBuilder.Entity<Questoes>()
            .Property(q => q.TextoQuestao)
            .IsRequired()  
            .HasColumnType("varchar(255)");

        modelBuilder.Entity<Questoes>()
            .HasOne(q => q.Quiz)
            .WithMany()
            .HasForeignKey(q => q.IdQuiz);

        modelBuilder.Entity<Questoes>()
            .HasOne(q => q.FlashCard)
            .WithMany()
            .HasForeignKey(q => q.IdFlashCard);
    
        //Materia 
        modelBuilder.Entity<Materia>()
            .Property(m => m.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");
    
        //Pontuação
        modelBuilder.Entity<Pontuacao>()
            .Property(p => p.PontosGerais)
            .HasColumnType("float");

        modelBuilder.Entity<Pontuacao>()
            .Property(p => p.PontosDeQuestoes)
            .HasColumnType("float");

        modelBuilder.Entity<Pontuacao>()
            .Property(p => p.PontosDeMaratona)
            .HasColumnType("float");
    }
    
}
