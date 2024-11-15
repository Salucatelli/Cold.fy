using AutoMapper;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Data.Dtos;
using ma2_banco_de_dados.Models;
using ma2_banco_de_dados.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace ma2_banco_de_dados.Controllers;

[ApiController]
[Route("[Controller]")]

public class UserController : ControllerBase
{
    private UserService _userService;
    private UserDbContext _context;

    public UserController(UserService userService, UserDbContext context)
    {
        _userService = userService;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateUserDto dto) //Create user
    {
        //return BadRequest(resultado.Errors);

        await _userService.Register(dto);
        return Ok("Usuario Cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);

        return Ok(token);
    }

    //implementar depois
    //[HttpPost("addpictrue")]
    //[Authorize]
    //public async Task<IActionResult> AddProfilePic([FromForm] string id, [FromForm] IFormFile file)
    //{
    //    byte[] dadosImagem = new byte[file.Length];
    //    await file.OpenReadStream().ReadAsync(dadosImagem, 0, (int)file.Length);

    //    var dto = new AddProfilePictureDto { ProfilePicture = dadosImagem };
    //    var user = await _userService.AddProfilPicture(id, dto);

    //    //return File(teste, "image/jpeg");
    //    return Ok(user);
    //}

    [HttpGet("id")]
    [Authorize]
    public async Task<IActionResult> SeeProfile()
    {
        string id = HttpContext.User.FindFirstValue("id");
        return Ok(id);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> SeeProfileId(string id)
    {
        var user = await _userService.getData(id);

        return Ok(user);
    }
}
