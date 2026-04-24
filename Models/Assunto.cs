using System.ComponentModel.DataAnnotations.Schema;
namespace MinhaLojaApi.Models;

public class Assunto
{
    public int IdAssunto { get; set; }
    public string Nome { get; set; }
    public string Topicos { get; set; }

    public int IdMateria { get; set;}

    [ForeignKey("IdMateria")]
    public Materia IdMateria;
    
}
