namespace MinhaLojaApi.Models;

public class FlashCard
{
    public int IdFlashCard { get; set; }
    public int IdTopico { get; set; }
    public string Pergunta { get; set; }
    public string Resposta { get; set; }
}
