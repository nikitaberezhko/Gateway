namespace Contracts.Tracking.Response;

public class GetStatusByOrderIdResponse
{
    public Guid Id { get; set; }
    
    public int CompletionPercent { get; set; }
    
    public int StatusType { get; set; }
}