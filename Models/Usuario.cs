using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string FotoPerfil { get; set; } = string.Empty;
    public string IdPost { get; set; } = string.Empty;

    [ForeignKey("IdPost")]
    public Post IdPost {get; set;}
}
