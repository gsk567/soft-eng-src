using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Testing.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILightService, LightService>();
builder.Services.AddScoped<ILightRepository, LightRepository>();
builder.Services.AddScoped<ILightValidator, LightValidator>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

public partial class Program {}