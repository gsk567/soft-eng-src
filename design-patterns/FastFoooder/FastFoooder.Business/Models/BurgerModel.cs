namespace FastFoooder.Business.Models;

public class BurgerModel : IFoodModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Meat { get; set; }

    public bool IsDoubleMeat { get; set; }

    public bool WithEgg { get; set; }

    public string Bread { get; set; }
}