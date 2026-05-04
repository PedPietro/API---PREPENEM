using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPREPENEM.Models;

public class Questoes
{
    [Key]
    public int IdQuestao { get; set; }

    public int IdQuiz { get; set; }

    [ForeignKey("IdQuiz")]
    public Quiz Quiz { get; set; } = null!;

    public int IdFlashCard { get; set; }

    [ForeignKey("IdFlashCard")]
    public FlashCard FlashCard { get; set; } = null!;

    [Required]
    public string TextoQuestao { get; set; } = string.Empty;
    
    public string? ImgQuestao { get; set; }

    public string? ImgNome { get; set; }
}

