using LogisticService.Domain.Entities;
using LogisticService.Domain.Exceptions;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.UseCases.Trucks;
using Moq;

namespace LogisticService.Test.Domain
{
    public class DeleteTruckUseCaseTest
    {
        private DeleteTruckUseCase _deleteTruckUseCase;

        [Test]
        public void Should_Not_Have_Errors_When_I_Try_To_Delete_Truck_Without_Services()
        {
            //ARRANGE
            var trucksRepo = new Mock<ITrucksRepository>();
            var servicesRepo = new Mock<IServicesRepository>();
            trucksRepo.Setup(m => m.GetByLicensePlate("1")).Returns(new TruckEntity());
            trucksRepo.Setup(m => m.Delete("1")).Returns(true);
            servicesRepo.Setup(m=> m.GetActiveServiceByLicensePlate("1"));
            servicesRepo.Setup(m=> m.GetAssignedServiceByLicensePlate("1"));
            _deleteTruckUseCase = new DeleteTruckUseCase(trucksRepo.Object, servicesRepo.Object);

            //ACTION 
            var result = _deleteTruckUseCase.Execute("1");

            //ASSERT
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Should_Throw_KeyNotFoundException_When_I_Try_To_Delete_Truck_Does_Not_Exist()
        {
            //ARRANGE
            var trucksRepo = new Mock<ITrucksRepository>();
            var servicesRepo = new Mock<IServicesRepository>();
            trucksRepo.Setup(m => m.GetByLicensePlate("1")).Returns(new TruckEntity());
            trucksRepo.Setup(m => m.Delete("1")).Returns(true);
            servicesRepo.Setup(m=> m.GetActiveServiceByLicensePlate("1"));
            servicesRepo.Setup(m=> m.GetAssignedServiceByLicensePlate("1"));
            _deleteTruckUseCase = new DeleteTruckUseCase(trucksRepo.Object, servicesRepo.Object);

            //ACTION - //ASSERT
            Assert.Throws<KeyNotFoundException>(()=> _deleteTruckUseCase.Execute("2"));
        }

        [Test]
        public void Should_Throw_CustomValidationException_When_I_Try_To_Delete_Truck_With_Active_Service()
        {
            //ARRANGE
            var trucksRepo = new Mock<ITrucksRepository>();
            var servicesRepo = new Mock<IServicesRepository>();
            trucksRepo.Setup(m => m.GetByLicensePlate("1")).Returns(new TruckEntity());
            trucksRepo.Setup(m => m.Delete("1")).Returns(true);
            servicesRepo.Setup(m=> m.GetActiveServiceByLicensePlate("1")).Returns(new ServiceEntity());
            servicesRepo.Setup(m=> m.GetAssignedServiceByLicensePlate("1"));
            _deleteTruckUseCase = new DeleteTruckUseCase(trucksRepo.Object, servicesRepo.Object);

            //ACTION - //ASSERT
            Assert.Throws<CustomValidationException>(()=> _deleteTruckUseCase.Execute("1"));
        }

        [Test]
        public void Should_Throw_CustomValidationException_When_I_Try_To_Delete_Truck_With_Assigned_Service()
        {
            //ARRANGE
            var trucksRepo = new Mock<ITrucksRepository>();
            var servicesRepo = new Mock<IServicesRepository>();
            trucksRepo.Setup(m => m.GetByLicensePlate("1")).Returns(new TruckEntity());
            trucksRepo.Setup(m => m.Delete("1")).Returns(true);
            servicesRepo.Setup(m=> m.GetActiveServiceByLicensePlate("1"));
            servicesRepo.Setup(m=> m.GetAssignedServiceByLicensePlate("1")).Returns(new ServiceEntity());
            _deleteTruckUseCase = new DeleteTruckUseCase(trucksRepo.Object, servicesRepo.Object);

            //ACTION - //ASSERT
            Assert.Throws<CustomValidationException>(()=> _deleteTruckUseCase.Execute("1"));
        }
    }
}