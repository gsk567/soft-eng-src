namespace FastFoooder.Data;

public class Burger : Entity
{
    public string Meat { get; set; }

    public bool IsDoubleMeat { get; set; }

    public bool WithEgg { get; set; }

    public string Bread { get; set; }
}