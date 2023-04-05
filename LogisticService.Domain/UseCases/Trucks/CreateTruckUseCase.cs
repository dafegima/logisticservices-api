using LogisticService.Domain.Entities;
using LogisticService.Domain.Exceptions;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Trucks
{
	public class CreateTruckUseCase : TrucksUseCaseBase, ICreateTruckUseCase
    {
        private readonly ITrucksRepository _trucksRepository;
        public CreateTruckUseCase(ITrucksRepository trucksRepository) : base(trucksRepository)
        {
            _trucksRepository = trucksRepository;
        }

        public TruckEntity Execute(TruckEntity truck)
        {
            if (TruckExist(truck.LicensePlate))
            {
                throw new ConflictException($"Truck with license plate {truck.LicensePlate} already exist.");
            }

            return _trucksRepository.Add(truck);
        }
    }
}

