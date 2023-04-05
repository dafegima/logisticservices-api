using AutoMapper;
using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using MediatR;

namespace LogisticService.Application.Commands.Trucks.Update
{
	public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, UpdateTruckCommandResponse>
	{
        private readonly IUpdateTruckUseCase _updateTruckUseCase;
        private readonly IMapper _mapper;
        public UpdateTruckCommandHandler(IUpdateTruckUseCase updateTruckUseCase, IMapper mapper)
        {
            _updateTruckUseCase = updateTruckUseCase;
            _mapper = mapper;
        }

        public async Task<UpdateTruckCommandResponse> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            TruckEntity truck = _mapper.Map<TruckEntity>(request);
            var result = _updateTruckUseCase.Execute(truck);
            return _mapper.Map<UpdateTruckCommandResponse>(result);
        }
    }
}

