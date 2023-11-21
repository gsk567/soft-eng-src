using System.Threading.Tasks;
using FastFoooder.Business.Models;
using FastFoooder.Data;

namespace FastFoooder.Business.FoodStrategies;

public interface IFoodStrategy<TFood>
    where TFood : Entity, new()
{
    IFoodModel Map(TFood foodEntity);

    TFood Map(IFoodModel foodEntity);
    
    decimal PriceCalculation(TFood foodModel);

    void ValidateFood(IFoodModel foodEntity);
}