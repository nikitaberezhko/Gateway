namespace WebApi.Models.Response.Order;

public class DeleteOrderResponse
{
    public Guid ClientId { get; set; }
    
    public Guid? ManagerId { get; set; }
    
    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public List<WorkUnitData> WorkUnits { get; set; }
}