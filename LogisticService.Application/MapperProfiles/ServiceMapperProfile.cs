using AutoMapper;
using LogisticService.Application.Commands.Services.Create;
using LogisticService.Domain.Entities;

namespace LogisticService.Application.MapperProfiles
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<ServiceEntity, CreateServiceCommandResponse>();
            CreateMap<CreateServiceCommand, ServiceEntity>();
        }   
    }
}