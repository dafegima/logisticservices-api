using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;

namespace LogisticService.Domain.UseCases.Trucks
{
    public class TrucksUseCaseBase
    {
        private readonly ITrucksRepository _trucksRepository;
        public TrucksUseCaseBase(ITrucksRepository trucksRepository)
        {
            _trucksRepository = trucksRepository;
        }

        public bool TruckExist(string licensePlate){
            return GetTruckByLicensePlate(licensePlate) is not null;
        }

        public TruckEntity GetTruckByLicensePlate(string licensePlate){
            return _trucksRepository.GetByLicensePlate(licensePlate);
        }
    }
}