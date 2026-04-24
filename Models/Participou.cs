using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class Participou
{
    public int IdParticipacao { get; set; }

    public int IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario IdUsuario { get; set; }

    public int IdMaratona { get; set; }

    [ForeignKey("IdMaratona")]
    public Maratona IdMaratona { get; set; }

    public double Pontos { get; set; }
}
