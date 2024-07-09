namespace Contracts.Tracking.Response;

public class GetStatusResponse
{
    public Guid OrderId { get; set; }
    
    public int CompletionPercent { get; set; }
    
    public int StatusType { get; set; }
}