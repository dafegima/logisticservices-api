using System;
using System.Net;
using LogisticService.Application.Commands.Trucks.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LogisticService.API.Endpoints.Trucks
{
    [Tags("Trucks")]
    [Route("api/trucks")]
    [Produces("application/json")]
    [ApiController]
    public class DeleteTruckEndpoint : Controller
	{
        private readonly IMediator _mediator;
        public DeleteTruckEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [HttpDelete("{licensePlate}")]
        public async Task<IActionResult> Delete(string licensePlate)
        {
            await _mediator.Send(new DeleteTruckCommand(licensePlate));
            return NoContent();
        }
    }
}