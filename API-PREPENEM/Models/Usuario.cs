using System.ComponentModel.DataAnnotations.Schema;
namespace APIPREPENEM.Models.Usuario;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Senha { get; set; } = string.Empty;

    public string? FotoPerfil { get; set; }
}


