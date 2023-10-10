namespace FotoVista.Service.DTOs;

public class UserResultDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string ProfilePictureUrl { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public string Role { get; set; } = string.Empty;
}
