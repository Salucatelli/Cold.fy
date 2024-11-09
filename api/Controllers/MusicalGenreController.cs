using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class MusicalGenreController : ControllerBase
{
    public UserDbContext _context;
    private IMapper _mapper;

    public MusicalGenreController(UserDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetGenre()
    {
        var genres = _context.MusicalGenres.ToList();

        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMusicalGenre([FromBody] CreateMusicalGenreDto dto)
    {
        try
        {
            MusicalGenre genre = _mapper.Map<MusicalGenre>(dto);

            _context.MusicalGenres.Add(genre);
            _context.SaveChanges();

            return Ok(genre);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteMusicalGenre(int id)
    {
        try
        {
            var genre = _context.MusicalGenres.FirstOrDefault(a => a.Id == id);
            _context.MusicalGenres.Remove(genre);
            _context.SaveChanges();
            return Ok(genre);
        }
        catch (Exception ex)
        {
            return BadRequest("Erro ao deletar");
        }
    }
}
