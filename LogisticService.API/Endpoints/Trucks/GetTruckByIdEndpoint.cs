using System;
using System.Net;
using LogisticService.Application.Queries.Trucks.GetAll;
using LogisticService.Application.Queries.Trucks.GetById;
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
    public class GetTruckByIdEndpoint : Controller
	{
        private readonly IMediator _mediator;
        public GetTruckByIdEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [HttpGet("{licensePlate}")]
        public async Task<IActionResult> Get(string licensePlate)
        {
            var result = await _mediator.Send(new GetTruckByIdQuery(licensePlate));
            return Ok(result);
        }
	}
}

