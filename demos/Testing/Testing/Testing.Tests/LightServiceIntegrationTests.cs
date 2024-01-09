using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Testing.Service;
using Xunit;

namespace Testing.Tests;

public class LightServiceIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory appFactory;

    public LightServiceIntegrationTests(CustomWebApplicationFactory appFactory)
    {
        this.appFactory = appFactory;
    }

    [Fact]
    public void GetLightsByColorWith_OnCorrectColor_ShouldReturnCorrectList()
    {
        using var scope = this.appFactory.Services.CreateScope();
        var lightService = scope
            .ServiceProvider
            .GetRequiredService<ILightService>();

        var lights = lightService.GetLightsByColor("red");
        lights.Should().HaveCount(2);
    }
}