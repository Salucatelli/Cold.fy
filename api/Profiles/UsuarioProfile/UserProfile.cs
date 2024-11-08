namespace ma2_banco_de_dados.Profiles.UsuarioProfile;
using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<AddProfilePictureDto, User>();
    }
}
