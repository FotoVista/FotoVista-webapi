namespace FotoVista.Service.DTOs;

public class CommentCreateDto
{
    public long PostId { get; set; }

    public long UserId { get; set; }

    public string Text { get; set; } = string.Empty;
}
