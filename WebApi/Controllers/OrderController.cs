using Asp.Versioning;
using AutoMapper;
using Contracts.CommonModels;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;
using Order.Contracts.Request.Order;
using Order.Contracts.Response.Order;
using Services.Models.Request;
using Services.Services.Abstractions;
using WebApi.Authorization;
using WebApi.CompositeModels;

namespace WebApi.Controllers;


[ApiController]
[Route("api/v{v:apiVersion}/orders")]
[ApiVersion(1.0)]
public class OrderController(
    IOrderApi orderApi,
    IOrderService orderService,
    IMapper mapper) : ControllerBase
{
    [Authorization(1)]
    [HttpPost]
    public async Task<ActionResult<CommonResponse<CreateOrderResponse>>> CreateOrder(
        CreateOrderRequest request)
    {
        var response = await orderApi.CreateOrder(request);
        return new CreatedResult(nameof(CreateOrder), response);
    }
    
    [Authorization(2)]
    [HttpPut]
    public async Task<ActionResult<CommonResponse<UpdateOrderResponse>>> UpdateOrder(
        UpdateOrderRequest request)
    {
        var response = await orderApi.UpdateOrder(request);
        return response;
    }
    
    [Authorization(1,2)]
    [HttpDelete]
    public async Task<ActionResult<CommonResponse<DeleteOrderResponse>>> DeleteOrder(
        DeleteOrderRequest request)
    {
        var response = await orderApi.DeleteOrder(request);
        return response;
    }
    
    [Authorization(2)]
    [HttpGet]
    public async Task<ActionResult<CommonResponse<GetAllOrdersResponse>>> GetAllOrders()
    {
        var response = await orderApi.GetAllOrders();
        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CommonResponse<OrderWithStatusResponse>>> GetOrderById(
        [FromRoute] GetOrderByIdRequest request)
    {
        var result = await orderService.CompositeOrderWithStatusById(
            mapper.Map<GetOrderByIdModel>(request));
        var response = new CommonResponse<OrderWithStatusResponse>
        {
            Data = mapper.Map<OrderWithStatusResponse>(result)
        };

        return response;
    }
    
    [Authorization(1,2)]
    [HttpGet("clients/{clientId:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByClientIdResponse>>> GetOrdersByClientId(
        [FromRoute] GetOrdersByClientIdRequest request)
    {
        var response = await orderApi.GetOrdersByClientId(request);
        return response;
    }
    
    [Authorization(2)]
    [HttpGet("managers/{managerId:guid}")]
    public async Task<ActionResult<CommonResponse<GetOrdersByManagerIdResponse>>> GetOrdersByManagerId(
        [FromRoute] GetOrdersByManagerIdRequest request)
    {
        var response = await orderApi.GetOrdersByManagerId(request);
        return response;
    }
}