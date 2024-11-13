using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ma2_banco_de_dados.Models;

public class Artist
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly BirthDate { get; set; }
   
    public List<MusicalGenre> MusicalGenres { get; set; } = new List<MusicalGenre>();
    public List<Album> Albums { get; set; } 
    public List<Music> Musics { get; set; }
}