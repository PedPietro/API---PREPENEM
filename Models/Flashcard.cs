using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class FlashCard
{
    [Key]
    public int IdFlashCard { get; set; };

    public int IdTopico { get; set; } = int.Empty;
  
    [ForeignKey("IdTopico")]
    public Assunto IdAssunto;

    [Required]
    public string Pergunta { get; set; } = string.Empty;
    
    [Required]
    public string Resposta { get; set; } = string.Empty;
}
