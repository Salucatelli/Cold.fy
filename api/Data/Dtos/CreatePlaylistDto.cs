using System.ComponentModel.DataAnnotations;

namespace ma2_banco_de_dados.Data.Dtos;

public class CreatePlaylistDto
{
    [Required]
    public string name { get; set; }
    public int code { get; set; }
    [Required]
    public string UserId { get; set; }
}
