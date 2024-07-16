using Contracts.CommonModels;
using Contracts.Order.Request.Order;
using Contracts.Order.Response.Order;
using Refit;

namespace Gateway.WebApi.RefitClients;

public interface IOrderApi
{
    [Get("/api/v1/orders")]
    Task<CommonResponse<GetAllOrdersResponse>> GetAllOrders();
    
    [Get("/api/v1/orders/{request.Id}")]
    Task<CommonResponse<GetOrderByIdResponse>> GetOrderById(
        GetOrderByIdRequest request);
    
    [Get("/api/v1/orders/clients/{request.ClientId}")]
    Task<CommonResponse<GetOrdersByClientIdResponse>> GetOrdersByClientId(
        GetOrdersByClientIdRequest request);
    
    [Get("/api/v1/orders/managers/{request.ManagerId}")]
    Task<CommonResponse<GetOrdersByManagerIdResponse>> GetOrdersByManagerId(
        GetOrdersByManagerIdRequest request);
    
    [Post("/api/v1/orders")]
    Task<CommonResponse<CreateOrderResponse>> CreateOrder(
        [Body] CreateOrderRequest request);
    
    [Put("/api/v1/orders")]
    Task<CommonResponse<UpdateOrderResponse>> UpdateOrder(
        [Body] UpdateOrderRequest request);
    
    [Delete("/api/v1/orders")]
    Task<CommonResponse<DeleteOrderResponse>> DeleteOrder(
        [Body] DeleteOrderRequest request);
}