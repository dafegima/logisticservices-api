using System;
using MediatR;

namespace LogisticService.Application.Commands.Trucks.Update
{
	public class UpdateTruckCommand : IRequest<UpdateTruckCommandResponse>
	{
		public UpdateTruckCommand(string licensePlate, string color, string brand, int yearModel)
		{
			LicensePlate = licensePlate;
			Color = color;
			Brand = brand;
			YearModel = yearModel;
		}

		public string LicensePlate { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int YearModel { get; set; }
    }
}

