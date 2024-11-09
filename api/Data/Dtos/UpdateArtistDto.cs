using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics.CodeAnalysis;

namespace ma2_banco_de_dados.Data.Dtos;

public class UpdateArtistDto
{
    public string name { get; set; }
    [AllowNull]
    public string description { get; set; }
}
