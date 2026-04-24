using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
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
