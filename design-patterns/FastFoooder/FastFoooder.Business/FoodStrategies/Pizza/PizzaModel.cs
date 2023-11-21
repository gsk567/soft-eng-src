using FastFoooder.Business.Models;
using FastFoooder.Data;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class PizzaModel : IFoodModel
{
    public virtual int Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual decimal Price { get; set; }
    
    public Size Size { get; set; }

    public string Dough { get; set; }

    public bool WithMeat { get; set; }

    public bool WithMushrooms { get; set; }
}