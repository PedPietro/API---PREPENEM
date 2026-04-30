using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaLojaApi.Models;

public class Participou
{
    [Key]
    public int IdParticipacao { get; set; }

    public int IdUsuario { get; set; } = int.Empty;

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; } // nome da propriedade = nome da classe

    public int IdMaratona { get; set; } = int.Empty; 

    [ForeignKey("IdMaratona")]
    public Maratona Maratona { get; set; }

    public double Pontos { get; set; } = double.Empty;
}