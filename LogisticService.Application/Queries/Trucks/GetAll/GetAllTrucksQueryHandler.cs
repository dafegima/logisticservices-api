using AutoMapper;
using LogisticService.Domain.Interfaces.UseCases.Trucks;
using MediatR;

namespace LogisticService.Application.Queries.Trucks.GetAll
{
    public class GetAllTrucksQueryHandler : IRequestHandler<GetAllTrucksQuery, IEnumerable<GetAllTrucksQueryResponse>>
    {
        private readonly IGetTrucksUseCase _getTrucksUseCase;
        private readonly IMapper _mapper;
        public GetAllTrucksQueryHandler(IGetTrucksUseCase getTrucksUseCase, IMapper mapper)
        {
            _getTrucksUseCase = getTrucksUseCase;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllTrucksQueryResponse>> Handle(GetAllTrucksQuery request, CancellationToken cancellationToken)
        {
            var result = _getTrucksUseCase.Execute();
            return _mapper.Map<IEnumerable<GetAllTrucksQueryResponse>>(result);
        }
    }
}