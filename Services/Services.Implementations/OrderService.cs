using AutoMapper;
using Contracts.CommonModels;
using Contracts.Order.Request.Order;
using Contracts.Tracking.Request;
using Gateway.WebApi.RefitClients;
using Services.Models.Request;
using Services.Models.Response;
using Services.Services.Abstractions;

namespace Services.Services.Implementations;

public class OrderService(
    IOrderApi orderApi, 
    ITrackingApi trackingApi,
    IMapper mapper) : IOrderService
{
    public async Task<OrderWithStatusModel> CompositeOrderWithStatusById(
        GetOrderByIdModel model)
    {
        var orderResponse = await orderApi.GetOrderById(
            new GetOrderByIdRequest { Id = model.Id });
        var trackingResponse = await trackingApi.GetStatusByOrderId(
            new GetStatusByOrderIdRequest { OrderId = model.Id });

        var result = mapper.Map<OrderWithStatusModel>(orderResponse.Data);
        
        result.StatusId = trackingResponse.Data.Id;
        result.CompletionPercent = trackingResponse.Data.CompletionPercent;
        result.StatusType = trackingResponse.Data.StatusType;
        
        return result;
    }
}