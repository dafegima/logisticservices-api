using LogisticService.Domain.Entities;

namespace LogisticService.Domain.Interfaces.UseCases.Services
{
    public interface ICreateServiceUseCase
    {
        ServiceEntity Execute(ServiceEntity service);
    }
}