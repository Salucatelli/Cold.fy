using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ma2_banco_de_dados.Data.Dtos;

public class CreateArtistDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly BirthDate { get; set; }
    [AllowNull]
    public int? MusicalGenreId { get; set; }
}
