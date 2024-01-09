using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Testing.Models;
using Xunit;

namespace Testing.Tests;

public class HttpRequestIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory appFactory;

    public HttpRequestIntegrationTests(CustomWebApplicationFactory appFactory)
    {
        this.appFactory = appFactory;
    }

    [InlineData("red", 2)]
    [InlineData("blue", 1)]
    [Theory]
    public async Task OnFetchColors_OnCorrectColor_ShouldReturnCorrectList(string color, int count)
    {
        var httpClient = this.appFactory.CreateClient();
        var response = await httpClient.GetStringAsync(new Uri($"http://localhost/test/{color}"));
        var lightCollection = JsonConvert.DeserializeObject<IEnumerable<LightModel>>(response);

        lightCollection.Should().HaveCount(count);
    }
}