namespace Contracts.Order.Request.Order;

public class CreateOrderRequest
{
    public Guid ClientId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
}