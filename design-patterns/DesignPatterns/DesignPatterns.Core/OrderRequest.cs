namespace DesignPatterns;

public class OrderRequest
{
    public OrderRequest()
    {
        this.Id = Guid.NewGuid();
    }
    
    public Guid Id { get; }

    public string DeliveryProviderId { get; set; }

    public double Weight { get; set; }
}