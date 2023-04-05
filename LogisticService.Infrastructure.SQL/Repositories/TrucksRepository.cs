using System.Text;
using LogisticService.Domain.Entities;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.SQL.Settings;
using Microsoft.Extensions.Options;

namespace LogisticService.Infrastructure.SQL.Repositories
{
    public class TrucksRepository : Base, ITrucksRepository
    {
        public TrucksRepository(IOptions<RepositorySettings> settings) : base (settings.Value.ConnectionString)
        {}

        public TruckEntity Add(TruckEntity truck)
        {
            StringBuilder sqlInsert = new StringBuilder();
            sqlInsert.Append("INSERT INTO Trucks (LicensePlate, Color, Brand, YearModel)");
            sqlInsert.Append("VALUES(@LicensePlate, @Color, @Brand, @YearModel)");            
            Execute(sqlInsert.ToString(), truck);

            return truck;
        }

        public bool Delete(string licensePlate)
        {
            StringBuilder sqlDelete = new StringBuilder();
            sqlDelete.Append("DELETE FROM Trucks WHERE LicensePlate = @LicensePlate");
            Execute(sqlDelete.ToString(), new {LicensePlate = licensePlate});
            return true;
        }

        public IEnumerable<TruckEntity> GetAll()
        {
            IEnumerable<TruckEntity> trucks;
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT * FROM Trucks");
            trucks = Query<TruckEntity>(sqlQuery.ToString());

            return trucks;
        }

        public TruckEntity GetByLicensePlate(string licensePlate)
        {
            TruckEntity truck;
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT * FROM Trucks WHERE LicensePlate = @LicensePlate");
            truck = Query<TruckEntity>(sqlQuery.ToString(), new {LicensePlate = licensePlate}).FirstOrDefault();

            return truck;
        }

        public TruckEntity Update(TruckEntity truck)
        {
            StringBuilder sqlUpdate = new StringBuilder();
            sqlUpdate.Append("UPDATE Trucks SET Color = @Color, Brand = @Brand, YearModel = @YearModel WHERE LicensePlate = @LicensePlate");
            Execute(sqlUpdate.ToString(), truck);
            
            return truck;
        }
    }
}