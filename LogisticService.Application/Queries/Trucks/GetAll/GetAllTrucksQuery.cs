using MediatR;

namespace LogisticService.Application.Queries.Trucks.GetAll
{
    public class GetAllTrucksQuery : IRequest<IEnumerable<GetAllTrucksQueryResponse>>
    {
        
    }
}