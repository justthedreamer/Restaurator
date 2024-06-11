using Infrastructure.DAL.Database;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DAL;

public static class Extensions
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerOption = configuration.GetOptions<SqlServerOptions>("sqlserver");

        services.AddDbContext<RestauratorDbContext>(options =>
            options.UseSqlServer(sqlServerOption.ConnectionString));

        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}