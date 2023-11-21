namespace FastFoooder.Data;

public class Pizza : Entity
{
    public string Crust { get; set; }
    
    public string Topping { get; set; }

    public Size Size { get; set; }

    public string Dough { get; set; }

    public bool WithMeat { get; set; }

    public bool WithMushrooms { get; set; }
}