using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

namespace ma2_banco_de_dados.Profiles.ArtistProfile
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<CreateArtistDto, Artist>();
            CreateMap<UpdateArtistDto, Artist>();
        }
    }
}
