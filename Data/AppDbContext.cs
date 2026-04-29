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
    // Representa a tabela de Clientes no banco de dados
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
        .HasColumnType("varchar(255)");

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

    // Flashcard
    modelBuilder.Entity<FlashCard>()
        .Property(f => f.Pergunta)
        .IsRequired()
        .HasColumnType("varchar(300)");

    // Assunto
    modelBuilder.Entity<Assunto>()
        .HasOne(a => a.Materia)
        .WithMany()
        .HasForeignKey(a => a.IdMateria);
}
    
}
/*Configuração da Conexão: appsettings.json
Abra o arquivo appsettings.json na raiz do projeto e adicione a "Connection String" (string de
conexão) com seu Servidor, Usuário e Senha do SQL Server. Deve ficar assim:
JSON*/
{
 "Logging": {
 "LogLevel": {
 "Default": "Information",
 "Microsoft.AspNetCore": "Warning"
 }
 },
 "AllowedHosts": "*",
 "ConnectionStrings": {
 "DefaultConnection": "Server=SEU_SERVIDOR;Database=MinhaLojaDB;User
Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
 }
}