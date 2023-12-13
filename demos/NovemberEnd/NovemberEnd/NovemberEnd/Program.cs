using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Essentials.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovemberEnd.Services.DummyApi;
using NovemberEnd.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthenticationCore(options =>
{
    options.AddScheme("Cookie", cb =>
    {
    });
});

var listOfPermissions = new List<string>
{
    "users.get",
    "users.create",
    "users.delete" // UsersDeletePolicy
};

builder.Services.AddAuthorizationCore(options =>
{
    foreach (var permission in listOfPermissions)
    {
        options.AddPolicy(CreatePolicyFromPermission(permission), policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("permission", permission);
        });
    }
    
});


builder.Services.AddHttpClient(HttpClientsConstants.DummyApiKey, client =>
{
    client.BaseAddress = new Uri(builder.Configuration["DummyApiBaseUrl"]);
});
builder.Services.AddScoped<IDummyApiService, DummyApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/test/{id}", (long id, IDummyApiService dummyApi) =>
    {
        return dummyApi.GetSingleEmployeeAsync(id);
    })
    .WithName("Test")
    .WithOpenApi();

app.Run();

string CreatePolicyFromPermission(string permission)
{
    var permissionSegments = permission.Split(".");
    var policyNameBuilder = new StringBuilder();
    foreach (var segment in permissionSegments)
    {
        policyNameBuilder.Append(segment.ToFirstUpper());
    }

    policyNameBuilder.Append("Policy");
    return policyNameBuilder.ToString();
}
