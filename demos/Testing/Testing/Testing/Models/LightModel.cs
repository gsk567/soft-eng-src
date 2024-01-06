using System;

namespace Testing.Models;

public class LightModel
{
    public Guid Id => Guid.NewGuid();

    public string Color { get; set; }

    public double Size { get; set; }
}