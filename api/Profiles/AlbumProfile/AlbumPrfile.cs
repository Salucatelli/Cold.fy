using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

namespace ma2_banco_de_dados.Profiles.AlbumProfile;

public class AlbumPrfile : Profile
{
    public AlbumPrfile()
    {
        CreateMap<CreateAlbumDto, Album>();
    }
}
