using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.Repositories
{
    public interface IServicesRepository
    {
        ServiceEntity Add(ServiceEntity service);
        ServiceEntity GetActiveServiceByLicensePlate(string licensePlate);
        IEnumerable<ServiceEntity> GetAll();
        ServiceEntity GetAssignedServiceByLicensePlate(string licensePlate);
    }
}