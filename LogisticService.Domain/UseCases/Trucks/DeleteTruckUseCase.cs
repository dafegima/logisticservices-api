using LogisticService.Domain.Exceptions;
using LogisticService.Domain.Exceptions.Models;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Trucks
{
    public class DeleteTruckUseCase : TrucksUseCaseBase, IDeleteTruckUseCase
    {
        private readonly ITrucksRepository _trucksRepository;
        private readonly IServicesRepository _servicesRepository;
        public DeleteTruckUseCase(ITrucksRepository trucksRepository, IServicesRepository servicesRepository) : base(trucksRepository)
        {
            _trucksRepository = trucksRepository;
            _servicesRepository = servicesRepository;
        }
        public bool Execute(string licensePlate)
        {
            if (TruckHasPendingService(licensePlate))
                throw new CustomValidationException(new List<CustomValidation>(){new CustomValidation(){Field="License Plate", Errors= new []{$"Truck with license plate {licensePlate} has a pending service and is not possible to delete it."}}});
            
            if (TruckExist(licensePlate))
                return _trucksRepository.Delete(licensePlate);

            throw new KeyNotFoundException($"Truck with license plate {licensePlate} does not exist.");
        }

        private bool TruckHasPendingService(string licensePlate)
        {
            return _servicesRepository.GetActiveServiceByLicensePlate(licensePlate) is not null || _servicesRepository.GetAssignedServiceByLicensePlate(licensePlate) is not null;
        }
    }
}