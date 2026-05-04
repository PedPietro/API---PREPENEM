using System.ComponentModel.DataAnnotations;

namespace APIPREPENEM.Models;

public class Pontuacao
{
    [Key]
    public int IdPontuacao { get; set; }
    public double PontosGerais { get; set; }
    public double PontosDeQuestoes { get; set; }
    public double PontosDeMaratona { get; set; }
}
