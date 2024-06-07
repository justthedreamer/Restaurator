using Razor_App.ApiClient;
using Razor_App.ApiClient.Abstraction;
using Razor_App.Configuration;
using Razor_App.Middleware;
using Razor_App.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IRestauratorApiClient, RestauratorApiClient>();
builder.Services.AddSingleton<ITokenService,TokenService>();

builder.Services.AddRazorPages();


var restauratorConfig = builder.Configuration.GetSection("restaurator-api");
builder.Services.Configure<RestauratorApiConfig>(restauratorConfig);

var app = builder.Build();

app.UseCookiePolicy();
app.UseAccessTokenMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();