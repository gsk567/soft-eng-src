using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Testing.Models;
using Testing.Service;
using Xunit;

namespace Testing.Tests;

public class LightServiceTests
{
    [Fact]
    public void GetLightsByColorWith_OnCorrectColorFromFake_ShouldReturnCorrectList()
    {
        // Arrange

        var lightValidatorMock = new Mock<ILightValidator>();
        var service = new LightService(
            new FakeLightRepository(), 
            lightValidatorMock.Object,
            Mock.Of<ILogger<LightService>>());

        // Act
        var lights = service.GetLightsByColor("red");

        // Assert
        lights
            .Should()
            .HaveCount(1);
    }
    
    [Fact]
    public void GetLightsByColorWith_OnCorrectColorFromStub_ShouldReturnCorrectList()
    {
        // Arrange

        var lightValidatorMock = new Mock<ILightValidator>();
        var repositoryStub = new Mock<ILightRepository>();
        repositoryStub
            .Setup(x => x.FetchLights())
            .Returns(new List<LightModel>
            {
                new LightModel
                {
                    Color = "red",
                    Size = 2.3,
                },
                new LightModel
                {
                    Color = "blue",
                    Size = 4.3,
                }
            });
        
        var service = new LightService(
            repositoryStub.Object,
            lightValidatorMock.Object,
            Mock.Of<ILogger<LightService>>());

        // Act
        var lights = service.GetLightsByColor("red");

        // Assert
        lights
            .Should()
            .HaveCount(1);
    }
    
    [Fact]
    public void GetLightsByColorWith_OnInvocation_ShouldFetchLights()
    {
        // Arrange
        var lightValidatorMock = new Mock<ILightValidator>();
        var repositoryMock = new Mock<ILightRepository>();
        repositoryMock
            .Setup(x => x.FetchLights())
            .Returns(new List<LightModel>
            {
                new LightModel
                {
                    Color = "red",
                    Size = 2.3,
                },
                new LightModel
                {
                    Color = "blue",
                    Size = 4.3,
                }
            });
        
        var service = new LightService(
            repositoryMock.Object,
            lightValidatorMock.Object,
            Mock.Of<ILogger<LightService>>());

        // Act
        var lights = service.GetLightsByColor("red");

        // Assert
        repositoryMock.Verify(x => x.FetchLights(), Times.Once);
        lights
            .Should()
            .HaveCount(1);
        lightValidatorMock
            .Verify(
                x => x.ValidateSize(It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(lights.Count()));
    }
}