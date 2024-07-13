using Asp.Versioning;
using Contracts.CommonModels;
using Contracts.Order.Request.Order;
using Contracts.Order.Response.Order;
using Gateway.WebApi.Authorization;
using Gateway.WebApi.RefitClients;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.WebApi.Controllers;


[ApiController]
[Route("api/v{v:apiVersion}/orders")]
[ApiVersion(1.0)]
public class OrderController(IOrderApi orderApi) : ControllerBase
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
    public async Task<ActionResult<CommonResponse<GetOrderByIdResponse>>> GetOrderById(
        [FromRoute] GetOrderByIdRequest request)
    {
        var response = await orderApi.GetOrderById(request);
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