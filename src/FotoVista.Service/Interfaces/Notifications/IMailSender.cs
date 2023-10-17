using FotoVista.Service.DTOs;

namespace FotoVista.Service.Interfaces;

public interface IMailSender
{
    public Task<bool> SendAsync(EmailMessage message);
}
