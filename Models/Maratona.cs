namespace MinhaLojaApi.Models;

public class Maratona
{
    public int IdMaratona { get; set; }
    public string Titulo { get; set; }
    public DateTime HoraInicio { get; set; }//usei TimeOnly para o tipo de dado ser um horário
    public DateTime HoraFim { get; set; }
    public string TipoDeMaratona { get; set; }

    public string DataDeCriacao { get; set; }
}
