using Chayxana.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Chayxana.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("localhost");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}