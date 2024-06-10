using AutoMapper;
using Infrastructure.Auth;
using Infrastructure.DAL;
using Infrastructure.Map;
using Infrastructure.QueryHandlers;
using Infrastructure.Repositories;
using Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSqlServer(configuration);
        services.AddHttpContextAccessor();
        services.AddAuth(configuration);

        services.AddSecurity(configuration);
        services.AddRepositories();
        services.AddAutoMapper(cfg => cfg.AddProfile(typeof(MainMapProfile)));
        services.AddQueryHandlers();
        
        
        return services;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}