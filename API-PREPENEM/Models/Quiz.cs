using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPREPENEM.Models;

public class Quiz
{
    [Key]
    public int IdQuiz { get; set; }

    public int IdAssunto { get; set; }

    [ForeignKey("IdAssunto")]
    public Assunto Assunto { get; set; } = null!;// null-forgiving operator 

    [Required]
    public string Enunciado { get; set; } = string.Empty;

    [Required]
    public string Explicacao { get; set; } = string.Empty;
    
    public double Pontuacao { get; set; }

    [Required]
    public string Alt_a { get; set; } = string.Empty;

    [Required]
    public string Alt_b { get; set; } = string.Empty;

    [Required]
    public string Alt_c { get; set; } = string.Empty;

    [Required]
    public string Alt_d { get; set; } = string.Empty;

    [Required]
    public string Alt_e { get; set; } = string.Empty;

    [Required]
    public string RespostaCorreta { get; set; } = string.Empty;
}
