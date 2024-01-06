using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Testing.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILightService, LightService>();
builder.Services.AddScoped<ILightRepository, LightRepository>();

var app = builder.Build();

app.Run();
