using System.ComponentModel.DataAnnotations;

namespace ma2_banco_de_dados.Data.Dtos;

public class CreateMusicalGenreDto
{
    [Required]
    public string Name {  get; set; }
    public string Description   { get; set; }
}
