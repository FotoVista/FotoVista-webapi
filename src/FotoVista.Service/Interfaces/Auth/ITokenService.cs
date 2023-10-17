using FotoVista.Domain.Entity;

namespace FotoVista.Service.Interfaces;

public interface ITokenService
{
    public string GenerateUserToken(UserEntity user);
}
