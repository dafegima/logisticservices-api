using System;
using FluentValidation;

namespace LogisticService.Application.Commands.Trucks.Delete
{
	public class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
	{
		public DeleteTruckCommandValidator()
		{
			RuleFor(cmd=> cmd.LicensePlate).NotEmpty().MaximumLength(10);
		}
	}
}

