using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
namespace MinhaLojaApi.Models;

public class Quiz
{
    [Key]
    public int IdQuiz { get; set; }

    public int IdTopico { get; set; } = int.Empty;

    [ForeignKey("IdTopico")]
    public Assunto Assunto;

    [Required]
    public string Enunciado { get; set; }

    [Required]
    public string Explicacao { get; set; }
    
    [Required]
    public double Pontuacao { get; set; }

    [Required]
    public string Alt_a { get; set; }

    [Required]
    public string Alt_b { get; set; }

    [Required]
    public string Alt_c { get; set; }

    [Required]
    public string Alt_d { get; set; }

    [Required]
    public string Alt_e { get; set; }


    [Required]
    public string RespostaCorreta { get; set; } = string.Empty;
}
