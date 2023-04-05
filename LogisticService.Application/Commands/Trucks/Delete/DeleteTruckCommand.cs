using System;
using MediatR;

namespace LogisticService.Application.Commands.Trucks.Delete
{
	public class DeleteTruckCommand : IRequest<bool>
	{
		public DeleteTruckCommand(string licensePlate)
		{
			LicensePlate = licensePlate;
		}
		public string LicensePlate { get; set; }
    }
}