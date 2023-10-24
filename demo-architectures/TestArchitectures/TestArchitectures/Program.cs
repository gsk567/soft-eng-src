using Application.Features.CreateDog;
using Application.Interfaces;
using Business;
using Data;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EntityContextNLayer>(options =>
{
    options.UseInMemoryDatabase("NLayer");
});

builder.Services.AddDbContext<EntityContextClean>(options =>
{
    options.UseInMemoryDatabase("Clean");
});

builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddScoped<IDogRepository, DogRepository>();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(CreateDogRequest).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
