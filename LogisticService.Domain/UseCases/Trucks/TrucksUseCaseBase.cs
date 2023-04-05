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
            return _trucksRepository.GetByLicensePlate(licensePlate) is not null;
        }
    }
}