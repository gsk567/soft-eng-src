namespace FastFoooder.Data;

public class Kebap : Entity
{
    public Size Size { get; set; }

    public bool WithMeat { get; set; }

    public bool ExtraSauce { get; set; }

    public bool WithFries { get; set; }
}