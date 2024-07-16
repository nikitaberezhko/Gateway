using Asp.Versioning;
using Contracts.CommonModels;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Order.Contracts.Request.WorkUnit;
using Order.Contracts.Response.WorkUnit;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/workunits")]
[ApiVersion(1.0)]
public class WorkUnitController(IWorkUnitApi workUnitApi) : ControllerBase
{
    [Authorization(2)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateWorkUnitResponse>>> CreateWorkUnit(
        CreateWorkUnitRequest request)
    {
        var response = await workUnitApi.CreateWorkUnit(request);
        return new CreatedResult(nameof(CreateWorkUnit), response);
    }

    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateWorkUnitResponse>>> UpdateWorkUnit(
        UpdateWorkUnitRequest request)
    {
        var response = await workUnitApi.UpdateWorkUnit(request);
        return response;
    }

    [Authorization(2)]
    [HttpDelete]
    public async Task<ActionResult<CommonResponse<DeleteWorkUnitResponse>>> DeleteWorkUnit(
        DeleteWorkUnitRequest request)
    {
        var response = await workUnitApi.DeleteWorkUnit(request);
        return response;
    }
}