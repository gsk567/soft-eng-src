using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoooder.Business.FoodStrategies;
using FastFoooder.Business.Models;
using FastFoooder.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoooder.Business.Services;

public class FoodService
{
    private readonly EntityContext context;
    private readonly FoodStrategyManager foodStrategyManager;

    public FoodService(
        EntityContext context,
        FoodStrategyManager foodStrategyManager
    )
    {
        this.context = context;
        this.foodStrategyManager = foodStrategyManager;
    }

    public async Task<IEnumerable<IFoodModel>> FetchFoodsAsync()
    {
        var foods = new List<IFoodModel>();

        var pizzas = await this.context
            .Pizzas
            .ToListAsync();
        
        foods.AddRange(pizzas.Select(x => this.foodStrategyManager.Map(x)));

        return foods;
    }

    public async Task<CreateFoodResult> CreateFoodAsync<TFood>(IFoodModel foodModel)
        where TFood : Entity, new()
    {
        try
        {
            this.foodStrategyManager.Validate<TFood>(foodModel);
            var food = this.foodStrategyManager.Create<TFood>(foodModel);
            food.Id = default;
            this.context.Add(food);
            await this.context.SaveChangesAsync();

            return new CreateFoodResult
            {
                FoodId = food.Id,
                Price = food.Price,
            };
        }
        catch (Exception e)
        {
            return new CreateFoodResult
            {
                Message = e.Message, // not recommended, but for the purpose of demo
            };
        }
    }
}