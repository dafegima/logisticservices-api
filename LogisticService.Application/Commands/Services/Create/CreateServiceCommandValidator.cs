using System.Runtime.InteropServices;
using System.ComponentModel;
using FluentValidation;

namespace LogisticService.Application.Commands.Services.Create
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(cmd=> cmd.LicensePlate).NotEmpty().MaximumLength(10);
            RuleFor(cmd=> cmd.Description).NotEmpty().MaximumLength(200);
            RuleFor(cmd=> cmd.Destination).NotEmpty().MaximumLength(50);
            RuleFor(cmd=> cmd.Origin).NotEmpty().MaximumLength(50);
            RuleFor(cmd=> cmd.OriginLatitude).NotEmpty();
            RuleFor(cmd=> cmd.OriginLongitude).NotEmpty();
            RuleFor(cmd=> cmd.DestinationLatitude).NotEmpty();
            RuleFor(cmd=> cmd.DestinationLongitude).NotEmpty();
        }
    }
}