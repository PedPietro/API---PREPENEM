namespace MinhaLojaApi.Models;

public class Materia
{

    [Key]
    public int IdMateria { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
}
