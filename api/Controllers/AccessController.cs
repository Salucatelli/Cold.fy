using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize]
    //[Authorize(Policy = "IdadeMinima")]
    public IActionResult Get()
    {
        return Ok("Parabéns, Você está logado!");
    }

    [HttpGet("teste")]
    [Authorize]
    public IActionResult teste()
    {
        return Ok("Deu certo!");
    }
}
