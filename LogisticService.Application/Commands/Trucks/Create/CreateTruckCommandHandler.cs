using AutoMapper;
using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using MediatR;

namespace LogisticService.Application.Commands.Trucks.Create
{
	public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, CreateTruckCommandResponse>
	{
        private readonly ICreateTruckUseCase _createTruckUseCase;
        private readonly IMapper _mapper;
        public CreateTruckCommandHandler(ICreateTruckUseCase createTruckUseCase, IMapper mapper)
        {
            _createTruckUseCase = createTruckUseCase;
            _mapper = mapper;
        }

        public async Task<CreateTruckCommandResponse> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            TruckEntity truck = _mapper.Map<TruckEntity>(request);
            var result = _createTruckUseCase.Execute(truck);
            return _mapper.Map<CreateTruckCommandResponse>(result);
        }
    }
}

