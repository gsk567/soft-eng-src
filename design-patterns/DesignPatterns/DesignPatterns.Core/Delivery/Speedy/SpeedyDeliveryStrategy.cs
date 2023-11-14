namespace DesignPatterns.Core.Delivery.Speedy;

public class SpeedyDeliveryStrategy : IDeliveryStrategy
{
    public string Id => "speedy";

    public string GenerateDeliveryMessage()
    {
        return "Speedy has taken your order";
    }
    
    public decimal CalculateShippingTax(double weight)
    {
        return (decimal)(weight * 0.22);
    }
}