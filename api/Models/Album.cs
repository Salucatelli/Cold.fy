using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ma2_banco_de_dados.Models;

public class Album
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    [Required]
    public int ArtistId { get; set; }
    [JsonIgnore]
    public Artist Artist { get; set; }
    public List<Music> Musics { get; set; } = new List<Music>();
}
