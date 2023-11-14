namespace DesignPatterns;

public class OrderResponse
{
    public Guid Id { get; set; }
    
    public string Message { get; set; }
    
    public decimal ShippingTax { get; set; }
}