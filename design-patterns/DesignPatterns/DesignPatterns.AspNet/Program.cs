using DesignPatterns;
using DesignPatterns.Adapter;
using DesignPatterns.AspNet.Adapters;
using DesignPatterns.AspNet.Data;
using DesignPatterns.AspNet.Repository;
using DesignPatterns.AspNet.Shared;
using DesignPatterns.Core.Delivery;
using DesignPatterns.Core.Delivery.Econt;
using DesignPatterns.Core.Delivery.Speedy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddScoped<UnitOfWork>()
    .AddScoped<IRepository, DogRepository>();

builder
    .Services
    .AddScoped<OrderService>();

builder
    .Services
    .AddScoped<IDeliveryStrategy, EcontDeliveryStrategy>()
    .AddScoped<IDeliveryStrategy, SpeedyDeliveryStrategy>();

builder
    .Services
    .AddDbContext<EntityContext>(options =>
    {
        options.UseSqlite(
            builder.Configuration.GetConnectionString("EntityContext"));
    });

builder
    .Services.AddScoped<TestActionFilterAttribute>();

builder
    .Services
    .AddScoped<PrintService>()
    .AddScoped<IDogsProviderAdapter, DogProviderAdapter>();

builder
    .Services
    .AddMediatR(options =>
    {
        options.RegisterServicesFromAssembly(typeof(Kebap).Assembly);
    });

builder.Services.AddControllers();

var app = builder.Build();

var serviceProvider = app
    .Services
    .CreateScope()
    .ServiceProvider;

try
{
    var dbContext = serviceProvider.GetRequiredService<EntityContext>();
    dbContext.Database.EnsureCreated();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();