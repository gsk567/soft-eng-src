using System;
using FastFoooder.Business.Models;
using FastFoooder.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoooder.Business.FoodStrategies;

public class FoodStrategyManager
{
    private readonly IServiceProvider serviceProvider;

    public FoodStrategyManager(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IFoodModel Map<TFood>(TFood food)
        where TFood : Entity, new()
    {
        var foodStrategy = GetStrategy<TFood>();

        return foodStrategy.Map(food);
    }
    
    public void Validate<TFood>(IFoodModel foodModel)
        where TFood : Entity, new()
    {
        var foodStrategy = GetStrategy<TFood>();
        foodStrategy.ValidateFood(foodModel);
    }

    public decimal CalculatePrice<TFood>(TFood food)
        where TFood : Entity, new()
    {
        var foodStrategy = GetStrategy<TFood>();
        return foodStrategy.PriceCalculation(food);
    }
    
    public TFood Create<TFood>(IFoodModel foodModel)
        where TFood : Entity, new()
    {
        var foodStrategy = GetStrategy<TFood>();
        return foodStrategy.Map(foodModel);
    }
    
    private IFoodStrategy<TFood> GetStrategy<TFood>()
        where TFood : Entity, new ()
    {
        try
        {
            var strategy = this.serviceProvider
                .GetRequiredService<IFoodStrategy<TFood>>();
            if (strategy == null)
            {
                throw new NotImplementedException();
            }

            return strategy;
        }
        catch (Exception e)
        {
            throw new NotImplementedException();
        }
    }
}