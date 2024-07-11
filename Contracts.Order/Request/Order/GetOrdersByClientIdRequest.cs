namespace Contracts.Order.Request.Order;

public class GetOrdersByClientIdRequest
{
    public Guid ClientId { get; set; }
}