namespace Contracts.Tracking.Request;

public class GetStatusByOrderIdRequest
{
    public Guid OrderId { get; set; }
}