using LogisticService.Application.Models;
using MediatR;

namespace LogisticService.Application.Commands.Services.Create
{
    public class CreateServiceCommand : ServiceBaseModel, IRequest<CreateServiceCommandResponse>
    {
    }
}