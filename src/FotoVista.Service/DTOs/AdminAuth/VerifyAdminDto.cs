namespace FotoVista.Service.DTOs;

public class VerifyAdminDto
{
    public string Email { get; set; } = String.Empty;
    public int Code { get; set; }
}
