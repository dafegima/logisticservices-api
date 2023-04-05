using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Trucks
{
    public interface IGetTrucksUseCase
    {
        IEnumerable<TruckEntity> Execute();
    }
}

