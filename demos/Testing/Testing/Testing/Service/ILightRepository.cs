using System.Collections.Generic;
using Testing.Models;

namespace Testing.Service;

public interface ILightRepository
{
    IEnumerable<LightModel> FetchLights();
}