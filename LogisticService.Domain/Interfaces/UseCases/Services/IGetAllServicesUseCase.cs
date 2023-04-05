using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Services
{
    public interface IGetAllServicesUseCase
    {
        IEnumerable<ServiceEntity> Execute();
    }
}