using AutoMapper;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using MediatR;

namespace LogisticService.Application.Queries.Trucks.GetById
{
    public class GetTruckByIdQueryHandler : IRequestHandler<GetTruckByIdQuery, GetTruckByIdQueryResponse>
    {
        private readonly IGetTruckByIdUseCase _getTruckByIdUseCase;
        private readonly IMapper _mapper;
        public GetTruckByIdQueryHandler(IGetTruckByIdUseCase getTruckByIdUseCase, IMapper mapper)
        {
            _getTruckByIdUseCase = getTruckByIdUseCase;
            _mapper = mapper;
        }
        public async Task<GetTruckByIdQueryResponse> Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _getTruckByIdUseCase.Execute(request.LicensePlate);
            return _mapper.Map<GetTruckByIdQueryResponse>(result);
        }
    }
}