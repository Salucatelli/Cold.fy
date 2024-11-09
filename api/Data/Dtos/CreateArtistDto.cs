namespace ma2_banco_de_dados.Data.Dtos;

public class CreateArtistDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly BirthDate { get; set; }
    public int MusicalGenreId { get; set; }
}
