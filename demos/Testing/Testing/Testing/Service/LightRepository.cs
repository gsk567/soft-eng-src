using System.Collections.Generic;
using Testing.Models;

namespace Testing.Service;

public class LightRepository : ILightRepository
{
    public IEnumerable<LightModel> FetchLights()
    {
        return new List<LightModel>();
    }
}