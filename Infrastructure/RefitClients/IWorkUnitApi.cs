using Contracts.CommonModels;
using Contracts.Order.Request.WorkUnit;
using Contracts.Order.Response.WorkUnit;
using Refit;

namespace Gateway.WebApi.RefitClients;

public interface IWorkUnitApi
{
    [Post("/api/v1/workunits")]
    Task<CommonResponse<CreateWorkUnitResponse>> CreateWorkUnit(
        CreateWorkUnitRequest request);

    [Put("/api/v1/workunits")]
    Task<CommonResponse<UpdateWorkUnitResponse>> UpdateWorkUnit(
        UpdateWorkUnitRequest request);

    [Delete("/api/v1/workunits")]
    Task<CommonResponse<DeleteWorkUnitResponse>> DeleteWorkUnit(
        DeleteWorkUnitRequest request);
}