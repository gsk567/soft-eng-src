namespace FastFoooder.Business.FoodStrategies.Pizza;

public abstract class PizzaValidatorHandler
{
    public abstract void Handle(PizzaMutationModel pizza);
}