using FluentValidation;

namespace LogisticService.Application.Commands.Trucks.Update
{
	public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
	{
		public UpdateTruckCommandValidator()
		{
			RuleFor(cmd=> cmd.LicensePlate).NotEmpty().MaximumLength(10);
            RuleFor(cmd => cmd.Color).NotEmpty().MaximumLength(50);
            RuleFor(cmd => cmd.Brand).NotEmpty().MaximumLength(50);
            RuleFor(cmd => cmd.YearModel).NotEmpty().GreaterThanOrEqualTo(1990).WithMessage("Year model should be a value greater than or equal to 1990");
		}
	}
}

