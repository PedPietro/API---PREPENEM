namespace MinhaLojaApi.Models;

public class Maratona
{
    public int IdMaratona { get; set; }
    public string Titulo { get; set; }
    public string HoraInicio { get; set; }
    public string HoraFim { get; set; }
    public string TipoDeMaratona { get; set; }

    public string DataDeCriacao { get; set; }
}
