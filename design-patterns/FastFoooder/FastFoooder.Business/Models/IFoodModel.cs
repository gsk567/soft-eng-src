namespace FastFoooder.Business.Models;

public interface IFoodModel
{
    int Id { get; set; }

    string Name { get; set; }
    
    decimal Price { get; set; }
}