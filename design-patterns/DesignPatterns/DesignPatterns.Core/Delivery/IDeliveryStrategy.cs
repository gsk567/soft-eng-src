namespace DesignPatterns.Core.Delivery;

public interface IDeliveryStrategy
{
    string Id { get; }
    
    string GenerateDeliveryMessage();

    decimal CalculateShippingTax(double weight);
}