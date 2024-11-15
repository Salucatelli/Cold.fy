﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ma2_banco_de_dados.Models;

public class MusicalGenre
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public List<Artist> Artists { get; set; }
}
