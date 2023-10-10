namespace FotoVista.Service.DTOs;

public class CommentResultDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;
}
