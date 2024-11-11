using ma2_banco_de_dados.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ma2_banco_de_dados.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]  // Requisitos para o token
        {
            new Claim("username", user.UserName!),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        }; 

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes /*Chave do token*/("ABABABABABABABABA203984u208ru20ru0")); 

        var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256); // Credentials

        var token = new JwtSecurityToken  /* token em si */
            (
            expires: DateTime.Now.AddMinutes(10000),
            claims: claims,
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token); // Convertendo o token para string
    }
}
