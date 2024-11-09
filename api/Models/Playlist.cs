using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ma2_banco_de_dados.Models;

public class Playlist
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Code { get; set; }
    [Required]
    public string UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    
    public List<Music> Musics { get; set; } = new List<Music>();
}
