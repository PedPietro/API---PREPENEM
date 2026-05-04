using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPREPENEM.Models;

public class FlashCard
{
    [Key]
    public int IdFlashCard { get; set; }

    public int IdTopico { get; set; }

    [ForeignKey("IdTopico")]
    public Assunto Assunto { get; set; } = null!;

    [Required]
    public string Pergunta { get; set; } = string.Empty;
    
    [Required]
    public string Resposta { get; set; } = string.Empty;
}
