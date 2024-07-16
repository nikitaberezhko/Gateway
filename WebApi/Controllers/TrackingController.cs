using Asp.Versioning;
using Contracts.CommonModels;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Tracking.Contracts.Request;
using Tracking.Contracts.Response;
using WebApi.Authorization;

namespace WebApi.Controllers;

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
    public async Task<ActionResult<CommonResponse<GetStatusByOrderIdResponse>>> GetStatusById(
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