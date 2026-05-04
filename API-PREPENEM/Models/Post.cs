using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPREPENEM.Models;

public class Post
{
    [Key]
    public int IdPost { get; set; }

    public string? Texto { get; set; }
    
    public string? Imagem { get; set; }

    public DateTime DataCriacao { get; set; }
    
    public int IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; } = null!;
}



