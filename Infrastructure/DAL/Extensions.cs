using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerOptions = configuration.GetOptions<AppOptions>("sqlserver");
        
        var sqlServerOption = configuration.GetOptions<SqlServerOptions>("sqlserver");

        services.AddDbContext<RestauratorDbContext>(options =>
            options.UseSqlServer(sqlServerOption.ConnectionString));

        return services;
    }
}