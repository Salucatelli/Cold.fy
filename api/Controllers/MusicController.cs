using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class MusicController : ControllerBase
{
    private UserDbContext _context;
    private IMapper _mapper;

    public MusicController(IMapper mapper, UserDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMusics()
    {
        var musics = _context.Music.ToList();

        return Ok(musics);  
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateMusic([FromBody] CreateMusicDto dto)
    {
        try
        {
            Music music = _mapper.Map<Music>(dto);

            music.Artist = _context.Artists.FirstOrDefault(a => a.Id == dto.ArtistId);

            music.Playlists = new List<Playlist>();
            music.Albums = new List<Album>();

            _context.Music.Add(music);
            _context.SaveChanges();

            return Ok(_context.Music.FirstOrDefault(m => m.Id == music.Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteMusic(int id)
    {
        try
        {
            var music = _context.Music.FirstOrDefault(a => a.Id == id);
            _context.Music.Remove(music);
            _context.SaveChanges();
            return Ok(music);
        }
        catch (Exception ex)
        {
            return BadRequest("Erro ao deletar");
        }
    }
}
