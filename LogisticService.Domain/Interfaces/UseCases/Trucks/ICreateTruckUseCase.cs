using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Trucks
{
    public interface ICreateTruckUseCase
    {
        TruckEntity Execute(TruckEntity truck);
    }
}

