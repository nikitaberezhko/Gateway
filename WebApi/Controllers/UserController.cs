using Asp.Versioning;
using Contracts.CommonModels;
using Gateway.WebApi.RefitClients;
using Identity.Contracts.Requests;
using Identity.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/users")]
[ApiVersion(1.0)]
public class UserController(IIdentityApi identityApi) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateUserResponse>>> CreateUser(
        CreateUserRequest request)
    {
        var response = await identityApi.CreateUser(request);
        return new CreatedResult(nameof(CreateUser), response);
    }

    [HttpDelete]
    public async Task<ActionResult<CommonResponse<DeleteUserResponse>>> DeleteUser(
        DeleteUserRequest request)
    {
        var response = await identityApi.DeleteUser(request);
        return response;
    }
    
    [HttpPost("authenticate")]
    public async Task<ActionResult<CommonResponse<AuthenticateUserResponse>>> AuthenticateUser(
        AuthenticateUserRequest request)
    {
        var response = await identityApi.AuthenticateUser(request);
        return response;
    }
}