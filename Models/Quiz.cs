namespace MinhaLojaApi.Models;

public class Quiz
{
    public int IdQuiz { get; set; }
    public int IdTopico { get; set; }
    public string Enunciado { get; set; }
    public string Explicacao { get; set; }
    public double Pontuacao { get; set; }

    public string Alt_a { get; set; }

    public string Alt_b { get; set; }

    public string Alt_c { get; set; }

    public string Alt_d { get; set; }

    public string Alt_e { get; set; }

    public string Alt_e { get; set; }

    public string RespostaCorreta { get; set; }
}
