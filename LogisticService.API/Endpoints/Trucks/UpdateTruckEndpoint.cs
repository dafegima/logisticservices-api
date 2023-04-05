using System.Net;
using LogisticService.Application.Commands.Trucks.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LogisticService.API.Endpoints.Trucks
{
    [Tags("Trucks")]
    [Route("api/trucks")]
    [Produces("application/json")]
    [ApiController]
    public class UpdateTruckEndpoint : Controller
	{
        private readonly IMediator _mediator;
        public UpdateTruckEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTruckCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

