namespace DesignPatterns.Core.Delivery.Econt;

public class EcontDeliveryStrategy : IDeliveryStrategy
{
    public string Id => "econt";

    public string GenerateDeliveryMessage()
    {
        return "Order has been shipped with Econt";
    }

    public decimal CalculateShippingTax(double weight)
    {
        return (decimal)(weight * 0.3);
    }
}