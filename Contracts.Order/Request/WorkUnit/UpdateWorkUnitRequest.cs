namespace WebApi.Models.Request.WorkUnit;

public class UpdateWorkUnitRequest
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}