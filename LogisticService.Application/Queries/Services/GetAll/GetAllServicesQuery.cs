using MediatR;

namespace LogisticService.Application.Queries.Services.GetAll
{
    public class GetAllServicesQuery : IRequest<IEnumerable<GetAllServicesQueryResponse>>
    {
        
    }
}