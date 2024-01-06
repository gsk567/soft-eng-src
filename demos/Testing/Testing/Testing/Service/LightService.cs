using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Testing.Models;

namespace Testing.Service;

public class LightService : ILightService
{
    private readonly ILightRepository lightRepository;
    private readonly ILightValidator lightValidator;
    private readonly ILogger<LightService> logger;

    public LightService(
        ILightRepository lightRepository,
        ILightValidator lightValidator,
        ILogger<LightService> logger)
    {
        this.lightRepository = lightRepository;
        this.lightValidator = lightValidator;
        this.logger = logger;
    }
    
    public IEnumerable<LightModel> GetLightsByColor(string color)
    {
        var result = this.lightRepository
            .FetchLights()
            .Where(x => x.Color == color);

        foreach (var light in result)
        {
            if (this.lightValidator.ValidateSize(light.Size, 3))
            {
                this.logger.LogWarning("Size is out of allowed range");
            }
        }
        
        return result;
    }
}