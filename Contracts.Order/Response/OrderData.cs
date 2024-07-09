namespace WebApi.Models.Response;

public class OrderData
{
    public Guid Id { get; set; }
    
    public Guid ClientId { get; set; }

    public Guid? ManagerId { get; set; }

    public string Model { get; set; }
    
    public string ModelProductionDate { get; set; }
    
    public List<WorkUnitData> WorkUnits { get; set; }
}