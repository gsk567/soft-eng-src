using FastFoooder.Data;

namespace FastFoooder.Business.Models;

public class KebapModel : IFoodModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public Size Size { get; set; }

    public bool WithMeat { get; set; }

    public bool ExtraSauce { get; set; }

    public bool WithFries { get; set; }
}