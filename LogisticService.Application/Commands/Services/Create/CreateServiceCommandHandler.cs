using AutoMapper;
using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.UseCases.Services;
using MediatR;

namespace LogisticService.Application.Commands.Services.Create
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, CreateServiceCommandResponse>
    {
        private readonly ICreateServiceUseCase _createServiceUseCase;
        private readonly IMapper _mapper;
        public CreateServiceCommandHandler(ICreateServiceUseCase createServiceUseCase, IMapper mapper)
        {
            _createServiceUseCase = createServiceUseCase;
            _mapper = mapper;
        }
        public async Task<CreateServiceCommandResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            ServiceEntity service = _mapper.Map<ServiceEntity>(request);
            var result = _createServiceUseCase.Execute(service);
            return _mapper.Map<CreateServiceCommandResponse>(result);
        }
    }
}