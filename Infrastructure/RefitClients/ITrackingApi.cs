using Contracts.CommonModels;
using Contracts.Tracking.Request;
using Contracts.Tracking.Response;
using Refit;

namespace Gateway.WebApi.RefitClients;

public interface ITrackingApi
{
    [Get("/api/v1/statuses")]
    Task<CommonResponse<GetStatusResponse>> GetStatus(
        [Body] GetStatusRequest request);
    
    [Get("/api/v1/statuses/orders/{request.OrderId}")]
    Task<CommonResponse<GetStatusByOrderIdResponse>> GetStatusByOrderId(
        GetStatusByOrderIdRequest request);
    
    [Put("/api/v1/statuses")]
    Task<CommonResponse<UpdateStatusResponse>> UpdateStatus(
        [Body] UpdateStatusRequest request);
}