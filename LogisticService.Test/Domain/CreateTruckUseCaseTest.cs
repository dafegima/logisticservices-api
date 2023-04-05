using LogisticService.Domain.Entities;
using LogisticService.Domain.Exceptions;
using LogisticService.Domain.Interfaces.Repositories;
using LogisticService.Domain.UseCases.Trucks;
using Moq;

namespace LogisticService.Test;

public class CreateTruckUseCaseTest
{
    private CreateTruckUseCase _createTruckUseCase;

    [Test]
    public void Should_Throw_Conflict_Exception_When_I_Try_To_Create_Truck_With_LicensePlate_Already_Axist()
    {
        //ARRANGE
        var repo = new Mock<ITrucksRepository>();
        repo.Setup(m => m.GetByLicensePlate("1")).Returns(new TruckEntity());
        _createTruckUseCase = new CreateTruckUseCase(repo.Object);

        //ACTION - //ASSERT
        Assert.Throws<ConflictException>(() => _createTruckUseCase.Execute(new TruckEntity() { LicensePlate = "1" }));
    }

    [Test]
    public void Should_Not_Have_Errors_When_I_Try_To_Create_Truck_With_LicensePlate_Not_Exist()
    {
        //ARRANGE
        TruckEntity truck = new TruckEntity();
        truck.LicensePlate = "2";
        var repo = new Mock<ITrucksRepository>();
        repo.Setup(m => m.GetByLicensePlate("1"));
        repo.Setup(m => m.Add(truck)).Returns(new TruckEntity());
        _createTruckUseCase = new CreateTruckUseCase(repo.Object);

        //ACTION
        var result = _createTruckUseCase.Execute(truck);

        //ASSERT
        Assert.IsNotNull(result);
        Assert.IsInstanceOf(typeof(TruckEntity), result);
    }
}
