using Application.Extensions;
using Core;
using Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using Web_API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Restaurator API", Version = "v1" });
});

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = String.Empty;
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurator v1");
});

app.Run();

