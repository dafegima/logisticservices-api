using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Trucks
{
    public interface IGetTruckByIdUseCase
    {
        TruckEntity Execute(string licensePlate);
    }
}