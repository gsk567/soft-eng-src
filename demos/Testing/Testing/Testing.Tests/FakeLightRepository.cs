using System.Collections.Generic;
using Testing.Models;
using Testing.Service;

namespace Testing.Tests;

public class FakeLightRepository : ILightRepository
{
    public IEnumerable<LightModel> FetchLights()
    {
        return new[]
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
        };
    }
}