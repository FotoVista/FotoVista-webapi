namespace FotoVista.Service.DTOs;

public class LikeResultDto
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
