using AutoMapper;
using Order.Contracts.Request.Order;
using Services.Models.Request;
using Services.Models.Response;
using WebApi.CompositeModels;

namespace WebApi.Mapping;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // Requests -> Request models
        CreateMap<GetOrderByIdRequest, GetOrderByIdModel>()
            .ForMember(d => d.Id, map => map.MapFrom(c => c.Id));

        // Response models -> Responses
        CreateMap<OrderWithStatusModel, OrderWithStatusResponse>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.WorkUnits, map => map.MapFrom(c => c.WorkUnits))
            .ForMember(d => d.StatusId, map => map.MapFrom(c => c.StatusId))
            .ForMember(d => d.CompletionPercent, map =>map.MapFrom(c => c.CompletionPercent))
            .ForMember(d => d.StatusType, map => map.MapFrom(c => c.StatusType));
    }
}