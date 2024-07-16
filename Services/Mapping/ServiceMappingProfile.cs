using AutoMapper;
using Contracts.Order.Response;
using Contracts.Order.Response.Order;
using Contracts.Tracking.Response;
using Services.Models.Response;

namespace Services.Mapping;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        // Services responses -> Models
        CreateMap<GetOrderByIdResponse, OrderWithStatusModel>()
            .ForMember(d => d.ClientId, map => map.MapFrom(c => c.ClientId))
            .ForMember(d => d.ManagerId, map => map.MapFrom(c => c.ManagerId))
            .ForMember(d => d.Model, map => map.MapFrom(c => c.Model))
            .ForMember(d => d.ModelProductionDate, map => map.MapFrom(c => c.ModelProductionDate))
            .ForMember(d => d.WorkUnits, map => map.MapFrom(c => c.WorkUnits))
            .ForMember(d => d.StatusId, map => map.Ignore())
            .ForMember(d => d.CompletionPercent, map => map.Ignore())
            .ForMember(d => d.StatusType, map => map.Ignore());
    }
    
}