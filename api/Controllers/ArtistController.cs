using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using ma2_banco_de_dados.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class ArtistController : ControllerBase
{
    public UserDbContext _context { get; set; }
    private IMapper _mapper;
    private ArtistService _artistService;

    public ArtistController(UserDbContext context, IMapper mapper, ArtistService artistService)
    {
        _context = context;
        _mapper = mapper;
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        try
        {
            var artists = _context.Artists.Include(a => a.MusicalGenres).ToList();

            if (artists is null)
                throw new ApplicationException("Erro");

            return Ok(artists);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetArtistById([FromQuery] int id)
    {
        try
        {
            var artist = _context.Artists.Include(a => a.Musics).Where(p => p.Id == id);

            if (artist is null)
                throw new ApplicationException("Erro");

            return Ok(artist);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateArtist([FromBody] CreateArtistDto dto)
    {
        try
        {
            var genreId = dto.MusicalGenreId;
            Artist artist = _mapper.Map<Artist>(dto);

            if (genreId != null)
            {
                var genre = await _context.MusicalGenres.FirstOrDefaultAsync(g => g.Id == genreId);
                artist.MusicalGenres.Add(genre);
            }

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return Ok(await _context.Artists.Where(a => a.Id == artist.Id).Include(a => a.MusicalGenres).ToListAsync());
        }
        catch (Exception ex)
        {
            return Ok("ta nullo");
        }
    }

    [HttpPut("update/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateArtist([FromBody] UpdateArtistDto dto, int id)
    {
        try
        {
            Artist artist = _context.Artists.FirstOrDefault(artist => artist.Id == id);
            _mapper.Map(dto, artist);

            _context.SaveChanges();
            return Ok(artist);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteArtist(int id)
    {
        try
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return Ok(artist);
        }
        catch (Exception ex)
        {
            return BadRequest("Erro ao deletar");
        }
    }
}
