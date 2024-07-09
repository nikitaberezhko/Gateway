
namespace Contracts.Tracking.Request;

public class UpdateStatusRequest
{
    public Guid Id { get; set; }
    
    public int CompletionPercent { get; set; }
    
    public int StatusType { get; set; }
}