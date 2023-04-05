using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Trucks
{
    public interface IUpdateTruckUseCase
    {
        TruckEntity Execute(TruckEntity truck);
    }
}