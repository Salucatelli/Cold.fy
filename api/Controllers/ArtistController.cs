using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class ArtistController : ControllerBase
{
    public UserDbContext _context { get; set; }

    public ArtistController(UserDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        var artistas = _context.Artists.ToList();

        return Ok(artistas);
    }

}
