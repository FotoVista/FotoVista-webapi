using FotoVista.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FotoVista.WebApi.Configurations.LayerConfigurations;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        
        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(connectionString));
    }
}
