using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Trucks
{
    public class GetTruckByIdUseCase : TrucksUseCaseBase, IGetTruckByIdUseCase
    {
        private readonly ITrucksRepository _trucksRepository;
        public GetTruckByIdUseCase(ITrucksRepository trucksRepository) : base(trucksRepository)
        {
            _trucksRepository = trucksRepository;
        }

        public TruckEntity Execute(string licensePlate)
        {
            TruckEntity truck = GetTruckByLicensePlate(licensePlate);
            if (truck is not null)
                return truck;

            throw new KeyNotFoundException($"Truck with license plate {licensePlate} does not exist.");
        }
    }
}