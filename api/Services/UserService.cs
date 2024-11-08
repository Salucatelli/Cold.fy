using AutoMapper;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ma2_banco_de_dados.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Register(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto); //Map userDto to user

        var result = await _userManager.CreateAsync(user, dto.Password); // add to database

        var response = result.ToString(); // Get the response message

        if (!result.Succeeded)
            throw new ApplicationException(response); 
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        // Login function
        var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

        if (!result.Succeeded)
            throw new ApplicationException("Erro ao autenticar usuário!"); // Throw if error

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper()); // Get the user infos from the DataBase 

        var token = _tokenService.GenerateToken(user); // generate the token

        return token;
    }

    public async Task<User> AddProfilPicture(string id, AddProfilePictureDto dto)
    {
        var user = await _userManager.FindByIdAsync(Convert.ToString(id));

        if (dto.ProfilePicture == null)
        {
            throw new ApplicationException("Vazio");
        }

        user.ProfilePicture = dto.ProfilePicture;
        var data = await _userManager.UpdateAsync(user);

        if (!data.Succeeded)
        {
            throw new ApplicationException("Erro no final");
        }

        var user2 = await _userManager.FindByIdAsync(Convert.ToString(id));

        return user2;


        //return userNovo.ProfilePicture;

        //var data = _userManager.(userNovo);

        //if (!data.Succeeded)
        //    Console.WriteLine("Erro aqui");
        //    throw new ApplicationException("Erro no final");
    }

    public async Task<User> See(string id)
    {
        var data = await _userManager.FindByIdAsync(id);

        return data;
    }
}
