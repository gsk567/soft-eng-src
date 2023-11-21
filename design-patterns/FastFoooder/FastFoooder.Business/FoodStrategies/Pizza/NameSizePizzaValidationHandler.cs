using System;
using System.Collections.Generic;
using System.Linq;
using FastFoooder.Data;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class NameSizePizzaValidationHandler : PizzaValidatorHandler
{
    public override void Handle(PizzaMutationModel pizza)
    {
        var validationRules = new List<bool>
        {
            pizza.Size == Size.Small && !pizza.Name.EndsWith("_S"),
            pizza.Size == Size.Medium && !pizza.Name.EndsWith("_M"),
            pizza.Size == Size.Large && !pizza.Name.EndsWith("_L"),
            pizza.Size == Size.ExtraLarge && !pizza.Name.EndsWith("_XL"),
        };

        if (validationRules.Any(x => x))
        {
            throw new InvalidPizzaException("Size and name don't match");
        }
    }
}