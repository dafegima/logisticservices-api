using LogisticService.Domain.Entities;
using LogisticService.Domain.Exceptions;
using LogisticService.Domain.Exceptions.Models;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Services;
using LogisticService.Domain.UseCases.Trucks;

namespace LogisticService.Domain.UseCases.Services
{
    public class CreateServiceUseCase : TrucksUseCaseBase, ICreateServiceUseCase
    {
        private readonly IServicesRepository _servicesRepository;
        public CreateServiceUseCase(IServicesRepository servicesRepository, ITrucksRepository trucksRepository) : base(trucksRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public ServiceEntity Execute(ServiceEntity service)
        {
            if (!TruckExist(service.LicensePlate))
                throw new CustomValidationException(new List<CustomValidation>(){new CustomValidation(){Field= "License Plate", Errors = new[]{$"License Plate {service.LicensePlate} does not exist"}}});

            if (TruckHasPendingService(service.LicensePlate))
                throw new ConflictException($"Truck with license plate {service.LicensePlate} has a pending service and is not possible to assign new service.");

            service.Status = "ASSIGNED";
            return _servicesRepository.Add(service);
        }

        private bool TruckHasPendingService(string licensePlate)
        {
            return _servicesRepository.GetActiveServiceByLicensePlate(licensePlate) is not null || _servicesRepository.GetAssignedServiceByLicensePlate(licensePlate) is not null;
        }
    }
}