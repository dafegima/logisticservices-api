using AutoMapper;
using LogisticService.Domain.Interfaces.UseCases.Services;
using MediatR;

namespace LogisticService.Application.Queries.Services.GetAll
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, IEnumerable<GetAllServicesQueryResponse>>
    {
        private readonly IGetAllServicesUseCase _getAllServicesUseCase;
        private readonly IMapper _mapper;
        public GetAllServicesQueryHandler(IGetAllServicesUseCase getAllServicesUseCase, IMapper mapper)
        {
            _getAllServicesUseCase = getAllServicesUseCase;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllServicesQueryResponse>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var result = _getAllServicesUseCase.Execute();
            return _mapper.Map<IEnumerable<GetAllServicesQueryResponse>>(result);
        }
    }
}