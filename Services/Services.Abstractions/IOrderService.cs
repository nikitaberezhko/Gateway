using Services.Models.Request;
using Services.Models.Response;

namespace Services.Services.Abstractions;

public interface IOrderService
{
    Task<OrderWithStatusModel> CompositeOrderWithStatusById(
        GetOrderByIdModel model);
}