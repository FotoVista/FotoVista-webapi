using FotoVista.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
namespace FotoVista_WebApi.Configurations;

public class DataAccessConfiguration
{
    private readonly IConfiguration _configuration;

    public DataAccessConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbContextOptions<AppDbContext> GetDbContextOptions()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString); 

        return optionsBuilder.Options;
    }
}

