using Asp.Versioning;
using Contracts.CommonModels;
using Contracts.Tracking.Request;
using Contracts.Tracking.Response;
using Gateway.WebApi.Authorization;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/statuses")]
[ApiVersion(1.0)]
public class TrackingController(ITrackingApi trackingApi) : ControllerBase
{
    [Authorization(1,2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetStatusResponse>>> GetStatus(
        GetStatusRequest request)
    {
        var response = await trackingApi.GetStatus(request);
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("orders/{orderId:guid}")]
    public async Task<ActionResult<CommonResponse<GetStatusByOrderIdResponse>>> GetStatusByOrderId(
        [FromRoute] GetStatusByOrderIdRequest request)
    {
        var response = await trackingApi.GetStatusByOrderId(request);
        return response;
    }

    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateStatusResponse>>> UpdateStatus(
        UpdateStatusRequest request)
    {
        var response = await trackingApi.UpdateStatus(request);
        return response;
    }
}