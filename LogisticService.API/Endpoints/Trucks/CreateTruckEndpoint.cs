using System;
using System.Net;
using LogisticService.Application.Commands.Trucks.Create;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LogisticService.API.Endpoints.Trucks
{
    [EnableCors("CorsPolicy")]
    [Tags("Trucks")]
    [Route("api/trucks")]
    [Produces("application/json")]
    [ApiController]
    public class CreateTruckEndpoint : Controller
	{
        private readonly IMediator _mediator;
        public CreateTruckEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.Conflict)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTruckCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

