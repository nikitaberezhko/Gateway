using Microsoft.AspNetCore.Mvc;

namespace Gateway.WebApi.Authorization;

public class AuthorizationAttribute : TypeFilterAttribute
{
    public AuthorizationAttribute(params int[] roles) : base(typeof(AuthorizationFilter))
    {
        Arguments = [roles];
    }
}