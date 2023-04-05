using AutoMapper;
using LogisticService.Application.Commands.Trucks.Create;
using LogisticService.Application.Commands.Trucks.Update;
using LogisticService.Application.Queries.Trucks.GetAll;
using LogisticService.Application.Queries.Trucks.GetById;
using LogisticService.Domain.Entities;

namespace LogisticService.Application.MapperProfiles
{
    public class TruckMapperProfiles: Profile
    {
        public TruckMapperProfiles()
        {
            CreateMap<CreateTruckCommand, TruckEntity>();
            CreateMap<TruckEntity, CreateTruckCommandResponse>();
            CreateMap<UpdateTruckCommand, TruckEntity>();
            CreateMap<TruckEntity, UpdateTruckCommandResponse>();
            CreateMap<TruckEntity, GetAllTrucksQueryResponse>();
            CreateMap<TruckEntity, GetTruckByIdQueryResponse>();
        }
    }
}