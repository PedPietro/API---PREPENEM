using Microsoft.AspNetCore.Mvc;
using MinhaLojaApi.Models; // Ajuste para o seu namespace

namespace MinhaLojaApi.Controllers;

[ApiController] // Indica que esta classe é uma API
[Route("api/[controller]")] // Define a rota como api/quiz
public class QuizController : ControllerBase
{

    [HttpGet]
    public IActionResult GetTodos() 
    {
        // Lógica para buscar no banco
        return Ok(new { mensagem = "Lista de quizzes" });
    }

    [HttpGet("{id}")]//
    public IActionResult GetPorId(int id)
    {
        return Ok(new { id = id, enunciado = "Exemplo de Quiz" });
    }

}