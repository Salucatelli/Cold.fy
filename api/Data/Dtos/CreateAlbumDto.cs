namespace ma2_banco_de_dados.Data.Dtos;

public class CreateAlbumDto
{
    public string name { get; set; }
    public string description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int ArtistId { get; set; }
}
