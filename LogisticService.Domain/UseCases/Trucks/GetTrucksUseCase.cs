using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Trucks
{
    public class GetTrucksUseCase : IGetTrucksUseCase
    {
        private readonly ITrucksRepository _trucksRepository;
        public GetTrucksUseCase(ITrucksRepository trucksRepository)
        {
            _trucksRepository = trucksRepository;
        }
        public IEnumerable<TruckEntity> Execute()
        {
            return _trucksRepository.GetAll();
        }
    }
}