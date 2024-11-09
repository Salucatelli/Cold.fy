using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ma2_banco_de_dados.Models;

public class Music
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Duration { get; set; }
    [Required]
    public int ArtistId { get; set; }

    [JsonIgnore]
    public Artist Artist { get; set; }
    [JsonIgnore]
    public List<Album> Albums { get; set; } = new List<Album>();
    [JsonIgnore]
    public List<Playlist> Playlists { get; set; } = new List<Playlist>();
}
