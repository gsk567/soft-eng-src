namespace DesignPatterns;

public class KebapRequest
{
    internal KebapRequest()
    {
    }
    
    public bool IsSpicy { get; internal set; }

    public bool WithVegitables { get; internal set; }

    public bool WithoutMeat { get; internal set; }
}