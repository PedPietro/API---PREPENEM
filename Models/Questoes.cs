using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class Questoes
{
    public int IdQuestao { get; set; }
    public int IdQuiz { get; set; }

    [ForeignKey("IdQuiz")]
    public Quiz IdQuiz;

    public int IdFlashCard { get; set; }

    [ForeignKey("IdFlashCard")]
    public FlashCard IdFlashCard;

    public string TextoQuestao { get; set; }
    public string? ImgQuestao { get; set; }

    public string? ImgNome { get; set; }
}
