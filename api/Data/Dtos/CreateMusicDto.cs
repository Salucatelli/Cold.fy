using System.ComponentModel.DataAnnotations;

namespace ma2_banco_de_dados.Data.Dtos;

public class CreateMusicDto
{
    [Required]
    public string name { get; set; }
    public int duration { get; set; }
    [Required]
    public int ArtistId { get; set; }
}
