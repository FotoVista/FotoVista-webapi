using FotoVista.Domain.Entity;

namespace FotoVista.Service.Interfaces
{
    public interface ITokenAdminService
    {
        public string GenerateAdminToken(UserEntity admin);
    }
}
