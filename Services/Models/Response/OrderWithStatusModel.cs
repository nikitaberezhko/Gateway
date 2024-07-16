using Contracts.Order.Response;

namespace Services.Models.Response;

public class OrderWithStatusModel
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