using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ma2_banco_de_dados.Models;

public class User : IdentityUser
{
    [Required]
    public DateTime BirthDate { get; set; }
    [AllowNull]
    public byte[] ProfilePicture { get; set; } = null;
    [AllowNull]
    public List<Playlist> Playlists { get; set; }

    //Serve para usar todas as propriedades do usuario do Identity
    public User() : base() { }
    
}
