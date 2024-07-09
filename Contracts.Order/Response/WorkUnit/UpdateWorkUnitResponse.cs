namespace WebApi.Models.Response.WorkUnit;

public class UpdateWorkUnitResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}