using System.Text;
using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.SQL.Settings;
using Microsoft.Extensions.Options;

namespace LogisticService.Infrastructure.SQL.Repositories
{
    public class ServicesRepository : Base, IServicesRepository
    {
        public ServicesRepository(IOptions<RepositorySettings> settings) : base(settings.Value.ConnectionString)
        {}

        public ServiceEntity Add(ServiceEntity service)
        {
            StringBuilder sqlInsert = new StringBuilder();
            sqlInsert.Append(" INSERT INTO Services (LicensePlate, Description, Origin, Destination, OriginLatitude,");
            sqlInsert.Append(" OriginLongitude, DestinationLatitude, DestinationLongitude, Status)");
            sqlInsert.Append(" Values(@LicensePlate, @Description, @Origin, @Destination, @OriginLatitude,");
            sqlInsert.Append(" @OriginLongitude, @DestinationLatitude, @DestinationLongitude, @Status)");

            Execute(sqlInsert.ToString(), service);
            return GetAssignedServiceByLicensePlate(service.LicensePlate);
        }

        public ServiceEntity GetAssignedServiceByLicensePlate(string licensePlate)
        {
            return GetByStatus("ASSIGNED", licensePlate);
        }

        public ServiceEntity GetActiveServiceByLicensePlate(string licensePlate)
        {
            return GetByStatus("ACTIVE", licensePlate);
        }

        private ServiceEntity GetByStatus(string status, string licensePlate)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT * FROM Services WHERE LicensePlate = @LicensePlate AND Status = @Status");
            ServiceEntity service = Query<ServiceEntity>(sqlQuery.ToString(), new {LicensePlate = licensePlate, Status = status}).FirstOrDefault();
            return service;
        }

        public IEnumerable<ServiceEntity> GetAll()
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT * FROM Services");
            return Query<ServiceEntity>(sqlQuery.ToString());
        }
    }
}