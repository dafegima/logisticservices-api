using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Trucks
{
    public class UpdateTruckUseCase : TrucksUseCaseBase, IUpdateTruckUseCase
    {
        private readonly ITrucksRepository _trucksRepository;
        public UpdateTruckUseCase(ITrucksRepository trucksRepository) : base(trucksRepository)
        {
            _trucksRepository = trucksRepository;
        }

        public TruckEntity Execute(TruckEntity truck)
        {
            if (TruckExist(truck.LicensePlate))
                return _trucksRepository.Update(truck);
            
            throw new KeyNotFoundException($"Truck with license plate {truck.LicensePlate} does not exits");
        }
    }
}