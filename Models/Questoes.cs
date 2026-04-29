using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class Questoes
{
    [Key]
    public int IdQuestao { get; set; };

    public int IdQuiz { get; set; } = int.Empty;

    [ForeignKey("IdQuiz")]
    public Quiz Quiz;

    public int IdFlashCard { get; set; } = int.Empty;

    [ForeignKey("IdFlashCard")]
    public FlashCard FlashCard;

    [Required]
    public string TextoQuestao { get; set; } = string.Empty;
    
    public string? ImgQuestao { get; set; };

    public string? ImgNome { get; set; };
}

