namespace FotoVista.Service.DTOs;

public class FollowerResultDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
