using Order.Contracts.Response;

namespace WebApi.CompositeModels;

public class OrderWithStatusResponse
{
    public Guid ClientId { get; set; }

    public Guid? ManagerId { get; set; }

    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public List<WorkUnitData> WorkUnits { get; set; }
    
    public Guid StatusId { get; set; }
    
    public int CompletionPercent { get; set; }
    
    public int StatusType { get; set; }
}