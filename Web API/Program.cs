using Infrastructure;
using Infrastructure.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer(builder.Configuration);

var app = builder.Build();

app.Run();

