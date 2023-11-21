namespace FastFoooder.Business.Models;

public class CakeModel : IFoodModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Icing { get; set; }

    public bool VeganFriendly { get; set; }

    public bool ForKids { get; set; }
}