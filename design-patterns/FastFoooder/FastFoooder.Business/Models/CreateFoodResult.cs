namespace FastFoooder.Business.Models;

public class CreateFoodResult
{
    public int? FoodId { get; set; }

    public decimal Price { get; set; }

    public string Message { get; set; }

    public bool Succeeded => FoodId.HasValue;
}