using FotoVista.Service.Interfaces;
using FotoVista.Service.Services;

namespace FotoVista.WebApi.Configurations.LayerConfigurations;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthAdminService, AuthAdminService>();
        //builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenAdminService, TokenAdminService>();
        builder.Services.AddScoped<IMailSender, MailSender>();
    }
}
