using System;

namespace Testing.Service;

public class LightValidator : ILightValidator
{
    public bool ValidateSize(double size, double expectedSize)
    {
        return size <= expectedSize;
    }
}