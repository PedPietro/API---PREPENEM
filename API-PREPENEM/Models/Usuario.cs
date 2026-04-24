namespace PREPENEMAPI.Models;

public class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public string FotoPerfil { get; set; } = string.Empty;
}