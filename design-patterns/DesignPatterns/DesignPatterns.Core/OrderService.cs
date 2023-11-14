using DesignPatterns.Core.Delivery;

namespace DesignPatterns;

public class OrderService
{
    private readonly IEnumerable<IDeliveryStrategy> deliveryStrategies;

    public OrderService(IEnumerable<IDeliveryStrategy> deliveryStrategies)
    {
        this.deliveryStrategies = deliveryStrategies;
    }
    
    public OrderResponse Process(OrderRequest request)
    {
        var response = new OrderResponse
        {
            Id = request.Id,
        };

        var deliveryStrategy = this.deliveryStrategies.FirstOrDefault(x => x.Id == request.DeliveryProviderId);
        response.Message = deliveryStrategy?.GenerateDeliveryMessage();
        response.ShippingTax = deliveryStrategy?.CalculateShippingTax(request.Weight) ?? -1;
        
        return response;
    }
}