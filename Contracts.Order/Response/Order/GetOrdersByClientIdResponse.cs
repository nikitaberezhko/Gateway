namespace Contracts.Order.Response.Order;

public class GetOrdersByClientIdResponse
{
    public List<OrderData> Orders { get; set; }
}