using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

namespace ma2_banco_de_dados.Profiles;

public class MusicalGenreProfile : Profile
{
    public MusicalGenreProfile()
    {
        CreateMap<CreateMusicalGenreDto, MusicalGenre>();
    }
}
