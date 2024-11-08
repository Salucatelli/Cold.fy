using System.ComponentModel.DataAnnotations;

namespace ma2_banco_de_dados.Models;

public class MusicalGenre
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Artist> Artists { get; set; }
}
