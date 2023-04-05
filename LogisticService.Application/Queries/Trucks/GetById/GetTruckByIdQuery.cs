using MediatR;

namespace LogisticService.Application.Queries.Trucks.GetById
{
    public class GetTruckByIdQuery : IRequest<GetTruckByIdQueryResponse>
    {
        public GetTruckByIdQuery(string licensePlate)
        {
            LicensePlate = licensePlate;
        }
        public string LicensePlate { get; set; }
    }
}