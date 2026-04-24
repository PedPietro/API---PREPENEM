namespace MinhaLojaApi.Models;

public class Questoes
{
    public int IdQuestao { get; set; }
    public int IdQuiz { get; set; }
    public int IdFlashCard { get; set; }
    public string TextoQuestao { get; set; }
    public string? ImgQuestao { get; set; }

    public string? ImgNome { get; set; }
}
