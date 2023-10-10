using Microsoft.AspNetCore.Http;
namespace FotoVista.Service.DTOs;

public class UserCreateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string UserName {  get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = default!;

    public string Bio { get; set; } = string.Empty;
}
