using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ma2_banco_de_dados.Services;

public class ArtistService
{
    private IMapper _mapper;
    private UserDbContext _context;
    public ArtistService(IMapper mapper, UserDbContext userDbContext = null)
    {
        _mapper = mapper;
        _context = userDbContext;
    }

    public async Task<List<Artist>> GetArtists()
    {
        var artists = _context.Artists.Include(a => a.MusicalGenres).ToList();

        if (artists is null)
            throw new ApplicationException("Erro");

        return artists;
    }

    public async Task CreateArtist(CreateArtistDto dto)
    {
        var genreId = dto.MusicalGenreId;
        var genre = await _context.MusicalGenres.FirstOrDefaultAsync(g => g.Id == genreId);

        Artist artist = _mapper.Map<Artist>(dto);
        artist.MusicalGenres = new List<MusicalGenre>() { genre };

        var result = _context.Artists.Add(artist);
        _context.SaveChanges();

        
    }  
}
