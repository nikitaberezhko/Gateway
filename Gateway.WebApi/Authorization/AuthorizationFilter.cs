using Contracts.CommonModels;
using Contracts.Identity.Requests;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gateway.WebApi.Authorization;

public class AuthorizationFilter(IIdentityApi identityApi, 
    params int[] roles) : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var token = context.HttpContext.Request.Headers["Authorization"].ToString();
        token = token.Split()[1];
        
        var response = identityApi.AuthorizeUser(new AuthorizationUserRequest
        {
            Token = token
        }).Result;
        
        if (!response.IsSuccessStatusCode)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Result = new JsonResult(response.Content);
            return;
        }

        if (!roles.Contains(response.Content.Data!.RoleId))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Result = new JsonResult(new CommonResponse<Empty>
            {
                Data = null,
                Error = new Error
                {
                    Title = "Access denied",
                    Message = "You don't have access to this endpoint",
                    StatusCode = StatusCodes.Status403Forbidden
                }
            });
        }
    }
}

record Empty{}