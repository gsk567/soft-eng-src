namespace DesignPatterns;

public class KebapRequestBuilder
{
    private KebapRequest request;

    public KebapRequestBuilder()
    {
        this.request = new KebapRequest();
    }

    public KebapRequestBuilder Spicy(bool spicy = true)
    {
        this.request.IsSpicy = spicy;
        return this;
    }
    
    public KebapRequestBuilder WithoutMeat(bool value = true)
    {
        this.request.WithoutMeat = value;
        return this;
    }
    
    public KebapRequestBuilder WithVegitables(bool value = true)
    {
        this.request.WithVegitables = value;
        return this;
    }
    
    public KebapRequest Build()
    {
        return this.request;
    }
}