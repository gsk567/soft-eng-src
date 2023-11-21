using System;
using FastFoooder.Business.FoodStrategies;
using FastFoooder.Business.FoodStrategies.Pizza;
using FastFoooder.Business.Services;
using FastFoooder.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .AddScoped<FoodService>()
    .AddScoped<FoodStrategyManager>()
    .AddScoped<IFoodStrategy<Pizza>, PizzaStrategy>();

builder
    .Services
    .AddDbContext<EntityContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("EntityContext"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

try
{
    var scope = app.Services.CreateScope();
    var entityContext = scope.ServiceProvider.GetRequiredService<EntityContext>();
    entityContext.Database.EnsureCreated();
}
catch (Exception)
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();