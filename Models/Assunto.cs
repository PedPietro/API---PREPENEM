using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
namespace MinhaLojaApi.Models;

public class Assunto
{
    [Key]
    public int IdAssunto { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Topicos { get; set; } = string.Empty;

    public int IdMateria { get; set;}  = string.Empty;

    [ForeignKey("IdMateria")]
    public Materia Materia;
    
}
/*

OUTRO JEITO CASO TUDO DE ERRADO:

//jeito 2

[Table('nomedatabela', Schema = 'nomeSchema')]

[Column('nomeDobglhnatabela')]
//declara dado , ex: Id {get; set;}

//bla bla bla 

//cria construto
public nomeDaClasse (propriedadesParametro)
    {
        this.Id = ID Parametro;
    }
*/