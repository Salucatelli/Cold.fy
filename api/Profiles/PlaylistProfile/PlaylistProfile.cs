using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

namespace ma2_banco_de_dados.Profiles.PlaylistProfile;

public class PlaylistProfile : Profile
{
    public PlaylistProfile()
    {
        CreateMap<CreatePlaylistDto, Playlist>();
    }
}
