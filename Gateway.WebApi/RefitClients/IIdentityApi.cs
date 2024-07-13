using Contracts.CommonModels;
using Contracts.Identity.Requests;
using Contracts.Identity.Responses;
using Refit;

namespace Gateway.WebApi.RefitClients;

public interface IIdentityApi
{
    [Post("/api/v1/users")]
    Task<CommonResponse<CreateUserResponse>> CreateUser(
        [Body] CreateUserRequest request);
    
    [Post("/api/v1/users/authenticate")]
    Task<CommonResponse<AuthenticateUserResponse>> AuthenticateUser(
        [Body] AuthenticateUserRequest request);
    
    [Post("/api/v1/users/authorize")]
    Task<ApiResponse<CommonResponse<AuthorizationResponse>>> AuthorizeUser(
        [Body] AuthorizationUserRequest request);
    
    [Delete("/api/v1/users")]
    Task<CommonResponse<DeleteUserResponse>> DeleteUser(
        [Body] DeleteUserRequest request);
}