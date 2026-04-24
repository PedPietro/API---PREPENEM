using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class FlashCard
{
    public int IdFlashCard { get; set; }
    public int IdTopico { get; set; }
  
    [ForeignKey("IdTopico")]
    public Assunto IdAssunto;

    public string Pergunta { get; set; }
    public string Resposta { get; set; }
}
