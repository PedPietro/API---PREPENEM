namespace MinhaLojaApi.Models;

public class Post
{
    [Key]
    public int IdPost { get; set; };

    public string? Texto { get; set; };
    
    public string? Imagem { get; set; };
    
    public int IdUsuario { get; set; }; = int.Empty;

    [ForeignKey("idUsuario")]
    public Usuario Usuario { get; set; };
}



