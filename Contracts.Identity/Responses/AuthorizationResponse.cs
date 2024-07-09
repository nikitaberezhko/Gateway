namespace Contracts.Identity.Responses;

public class AuthorizationResponse
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
}