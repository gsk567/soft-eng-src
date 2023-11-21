using System;
using System.Linq;
using FastFoooder.Business.Models;
using FastFoooder.Data;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class PizzaStrategy : IFoodStrategy<Data.Pizza>
{
    public IFoodModel Map(Data.Pizza foodEntity) =>
        MapPizza(foodEntity);

    public Data.Pizza Map(IFoodModel foodModel)
    {
        if (foodModel == null)
        {
            throw new ArgumentNullException();
        }

        var allowedFoodTypes = new Type[]
        {
            typeof(PizzaModel),
            typeof(PizzaMutationModel),
        };
            
        if (!allowedFoodTypes.Contains(foodModel.GetType()))
        {
            throw new InvalidOperationException();
        }

        var pizzaModel = foodModel as PizzaModel;

        var pizzaEntity = new Data.Pizza
        {
            Id = pizzaModel.Id,
            Name = pizzaModel.Name,
            WithMeat = pizzaModel.WithMeat,
            WithMushrooms = pizzaModel.WithMushrooms,
            Size = pizzaModel.Size,
            Dough = pizzaModel.Dough,
        };

        pizzaEntity.Price = PriceCalculation(pizzaEntity);
        
        return pizzaEntity;
    }

    public decimal PriceCalculation(Data.Pizza footEntity)
    {
        var priceBuilder = new PizzaPriceBuilder();
        return priceBuilder
            .WithMushrooms(footEntity.WithMushrooms)
            .WithMeat(footEntity.WithMeat)
            .ForSize(footEntity.Size)
            .Build();
    }

    public void ValidateFood(IFoodModel foodEntity)
    {
        var validator = new PizzaValidator();
        validator.Validate(foodEntity as PizzaMutationModel);
    }

    private PizzaModel MapPizza(Data.Pizza pizza)
    {
        return new PizzaModel
        {
            Id = pizza.Id,
            Name = pizza.Name,
            WithMeat = pizza.WithMeat,
            WithMushrooms = pizza.WithMushrooms,
            Size = pizza.Size,
            Price = pizza.Price,
            Dough = pizza.Dough,
        };
    }
}