using System;
namespace LogisticService.Domain.Interfaces.UseCases.Trucks
{
    public interface IDeleteTruckUseCase
    {
        bool Execute(string licensePlate);
    }
}

