using AutoMapper;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using MediatR;

namespace LogisticService.Application.Commands.Trucks.Delete
{
	public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand, bool>
	{
        private readonly IDeleteTruckUseCase _deleteTruckUseCase;
        private readonly IMapper _mapper;
        public DeleteTruckCommandHandler(IDeleteTruckUseCase deleteTruckUseCase, IMapper mapper)
        {
            _deleteTruckUseCase = deleteTruckUseCase;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            return _deleteTruckUseCase.Execute(request.LicensePlate);
        }
    }
}

