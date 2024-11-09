using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class AlbumController : ControllerBase
{
    private IMapper _mapper;
    private UserDbContext _context;

    public AlbumController(IMapper mapper, UserDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        try
        {
            var albums = _context.Album.Include(a => a.Musics).ToList();

            if (albums is null)
                throw new ApplicationException("Erro");

            return Ok(albums);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlbum(CreateAlbumDto dto)
    {
        try
        {
            Album album = _mapper.Map<Album>(dto);

            album.Artist = _context.Artists.FirstOrDefault(a => a.Id == dto.ArtistId);

            _context.Album.Add(album);
            _context.SaveChanges();

            return Ok(_context.Album.FirstOrDefault(m => m.Id == album.Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("addmusic/{id}")]
    public async Task<IActionResult> AddMusic([FromQuery] int musicid, int id)
    {
        try
        {
            Music music = _context.Music.FirstOrDefault(m => m.Id == musicid);
            Album album = _context.Album.FirstOrDefault(a => a.Id == id);

            album.Musics.Add(music);
            music.Albums.Add(album);

            _context.SaveChanges();
            return Ok(album);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        try
        {
            var album = _context.Album.FirstOrDefault(a => a.Id == id);
            _context.Album.Remove(album);
            _context.SaveChanges();
            return Ok(album);
        }
        catch (Exception ex)
        {
            return BadRequest("Erro ao deletar");
        }
    }
}
