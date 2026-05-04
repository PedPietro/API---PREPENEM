using System.ComponentModel.DataAnnotations;

namespace APIPREPENEM.Models;

public class Maratona
{
    [Key]
    public int IdMaratona { get; set; }

    [Required]
    [MaxLength(100)]
    public string Titulo { get; set; } = string.Empty;

    public TimeOnly HoraInicio { get; set; }  // TimeOnly é ideal para horário sem data

    public TimeOnly HoraFim { get; set; }

    [MaxLength(50)]
    public string TipoDeMaratona { get; set; } = string.Empty;

    public DateTime DataDeCriacao { get; set; } = DateTime.UtcNow;
}