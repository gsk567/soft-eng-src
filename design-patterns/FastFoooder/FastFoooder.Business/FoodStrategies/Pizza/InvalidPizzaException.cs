using System;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class InvalidPizzaException : Exception
{
    public InvalidPizzaException(string message)
        : base(message)
    {
    }
}