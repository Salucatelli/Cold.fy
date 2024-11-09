using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

namespace ma2_banco_de_dados.Profiles.MusicProfile;

public class MusicProfile : Profile
{
    public MusicProfile()
    {
        CreateMap<CreateMusicDto, Music>();
        CreateMap<AddMusicDto, Music>();
    }
}
