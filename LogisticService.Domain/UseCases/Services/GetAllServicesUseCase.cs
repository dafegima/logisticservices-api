using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.Interfaces.UseCases.Services;

namespace LogisticService.Domain.UseCases.Services
{
    public class GetAllServicesUseCase : IGetAllServicesUseCase
    {
        private readonly IServicesRepository _servicesRepository;
        public GetAllServicesUseCase(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public IEnumerable<ServiceEntity> Execute()
        {
            return _servicesRepository.GetAll();
        }
    }
}