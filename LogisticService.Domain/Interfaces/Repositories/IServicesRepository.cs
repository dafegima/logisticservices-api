using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.Repositories
{
    public interface IServicesRepository
    {
        ServiceEntity Add(ServiceEntity service);
        ServiceEntity GetActiveServiceByLicensePlate(string licensePlate);
        ServiceEntity GetAssignedServiceByLicensePlate(string licensePlate);
    }
}