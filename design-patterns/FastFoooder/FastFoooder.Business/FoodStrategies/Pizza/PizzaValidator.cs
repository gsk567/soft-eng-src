using System.Collections.Generic;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class PizzaValidator
{
    private IEnumerable<PizzaValidatorHandler> handlers;

    public PizzaValidator()
    {
        var handlers = new List<PizzaValidatorHandler>();
        handlers.Add(new NameSizePizzaValidationHandler());
        this.handlers = handlers;
    }
    
    public void Validate(PizzaMutationModel pizza)
    {
        foreach (var handler in this.handlers)
        {
            handler.Handle(pizza);
        }
    }
}