using System.Collections.Generic;
using Testing.Models;

namespace Testing.Service;

public class LightRepository : ILightRepository
{
    public IEnumerable<LightModel> FetchLights()
    {
        return new List<LightModel>
        {
            new LightModel
            {
                Color = "red",
                Size = 3,
            },
            new LightModel
            {
                Color = "red",
                Size = 3,
            },new LightModel
            {
                Color = "blue",
                Size = 3,
            }
        };
    }
}