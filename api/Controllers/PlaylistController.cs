﻿using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class PlaylistController : ControllerBase
{
    private IMapper _mapper;
    private UserDbContext _context;

    public PlaylistController(IMapper mapper, UserDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPlaylist()
    {
        try
        {
            var playlists = _context.Playlist.Include(a => a.Musics).ToList();

            if (playlists is null)
                throw new ApplicationException("Erro");

            return Ok(playlists);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlaylist(CreatePlaylistDto dto)
    {
        try
        {
            Playlist playlist= _mapper.Map<Playlist>(dto);

            playlist.User = _context.Users.FirstOrDefault(a => a.Id == dto.UserId);

            _context.Playlist.Add(playlist);
            _context.SaveChanges();

            return Ok(_context.Playlist.FirstOrDefault(m => m.Id == playlist.Id));
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
            Playlist playlist = _context.Playlist.FirstOrDefault(a => a.Id == id);

            playlist.Musics.Add(music);
            music.Playlists.Add(playlist);

            _context.SaveChanges();
            return Ok(playlist);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}