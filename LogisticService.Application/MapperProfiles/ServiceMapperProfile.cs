using AutoMapper;
using LogisticService.Application.Commands.Services.Create;
using LogisticService.Application.Queries.Services.GetAll;
using LogisticService.Domain.Entities;

namespace LogisticService.Application.MapperProfiles
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<ServiceEntity, CreateServiceCommandResponse>();
            CreateMap<CreateServiceCommand, ServiceEntity>();
            CreateMap<ServiceEntity, GetAllServicesQueryResponse>();
        }   
    }
}