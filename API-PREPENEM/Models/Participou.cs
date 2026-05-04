using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPREPENEM.Models;

public class Participou
{
    [Key]
    public int IdParticipacao { get; set; }

    public int IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; } = null!;

    public int IdMaratona { get; set; }

    [ForeignKey("IdMaratona")]
    public Maratona Maratona { get; set; } = null!;

    public double Pontos { get; set; }
}