using FastFoooder.Data;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class PizzaPriceBuilder
{
    private decimal price = 10;
    private Size? appliedSize;

    public PizzaPriceBuilder WithMushrooms(bool value = true)
    {
        if (value)
        {
            this.price += 2;
        }

        return this;
    }
    
    public PizzaPriceBuilder WithMeat(bool value = true)
    {
        if (value)
        {
            this.price += 5;
        }

        return this;
    }

    public PizzaPriceBuilder ForSize(Size size = Size.Small)
    {
        if (this.appliedSize.HasValue)
        {
            return this;
        }
        
        switch (size)
        {
            case Size.Small:
                break;
            case Size.Medium:
                this.price += 1;
                break;
            case Size.Large:
                this.price += 2;
                break;
            case Size.ExtraLarge:
                this.price += 4;
                break;
            default:
                break;
        }

        this.appliedSize = size;
        
        return this;
    }
    
    public decimal Build()
    {
        return this.price;
    }
}