using System.Collections.Generic;
using Testing.Models;

namespace Testing.Service;

public interface ILightService
{
    IEnumerable<LightModel> GetLightsByColor(string color);
}