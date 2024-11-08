using System.ComponentModel.DataAnnotations;

namespace ma2_banco_de_dados.Data.Dtos;

public class AddProfilePictureDto
{
    [Required]
    public byte[] ProfilePicture { get; set; }
}
