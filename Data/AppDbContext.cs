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
        // Define que todas as tabelas ficarão dentro do schema "API" no SQL Server
        modelBuilder.HasDefaultSchema("API");

        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);

        // Define que o Nome é obrigatório e tem limite de 50 caracteres (varchar)
        modelBuilder.Entity<Usuario>().Property(u =>
        u.Nome).IsRequired().HasColumnType("varchar(50)");

        modelBuilder.Entity<Usuario>().Property(c =>
        c.Telefone).IsRequired().HasColumnType("varchar(15)");
        // --- CONFIGURANDO A TABELA PEDIDO ---

        // Define que o IdPedido é a Chave Primária (PK)
        modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);

        // Define que a DataPedido é obrigatória e do tipo datetime
        modelBuilder.Entity<Pedido>().Property(p =>
        p.DataPedido).IsRequired().HasColumnType("datetime");

        // Define que o ValorTotal usa o tipo money no SQL Server
        modelBuilder.Entity<Pedido>().Property(p => p.ValorTotal).HasColumnType("money");
        // Cria a relação de Chave Estrangeira (FK): Um Pedido tem Um Cliente
        modelBuilder.Entity<Pedido>()
        // Diz que o Pedido tem 1 Cliente (relacionamento lógico)
        .HasOne<Cliente>()
        // Diz que um Cliente pode ter muitos pedidos (WithMany fica vazio pois não foi mapeada a lista na classe Cliente)
        .WithMany()
        // Aponta que a chave estrangeira na tabela Pedido é a propriedade IdCliente
        .HasForeignKey(p => p.IdCliente);
    }
    
}
Configuração da Conexão: appsettings.json
Abra o arquivo appsettings.json na raiz do projeto e adicione a "Connection String" (string de
conexão) com seu Servidor, Usuário e Senha do SQL Server. Deve ficar assim:
JSON
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