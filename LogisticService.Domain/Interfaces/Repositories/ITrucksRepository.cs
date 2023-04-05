
using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.Repositories
{
    public interface ITrucksRepository
    {
        TruckEntity Add(TruckEntity truck);
        bool Delete(string licensePlate);
        TruckEntity Update(TruckEntity truck);
        IEnumerable<TruckEntity> GetAll();
        TruckEntity GetByLicensePlate(string licensePlate);
    }
}