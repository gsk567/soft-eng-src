namespace FastFoooder.Business.Models;

public class ShkembeModel : IFoodModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public bool IsSpicy { get; set; }

    public bool WithGarlic { get; set; }
}