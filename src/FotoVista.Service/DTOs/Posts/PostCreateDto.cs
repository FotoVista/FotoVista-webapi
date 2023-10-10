using Microsoft.AspNetCore.Http;

namespace FotoVista.Service.DTOs;

public class PostCreateDto
{
    public long UserId {  get; set; }

    public string Caption { get; set; } = string.Empty;

    public IFormFile ?ImageUrl{ get; set; } = default!;
}
