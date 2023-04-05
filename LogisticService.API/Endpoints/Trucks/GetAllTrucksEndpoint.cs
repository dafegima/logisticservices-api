using System;
using System.Net;
using LogisticService.Application.Queries.Trucks.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LogisticService.API.Endpoints.Trucks
{
    [Tags("Trucks")]
    [Route("api/trucks")]
    [Produces("application/json")]
    [ApiController]
    public class GetAllTrucksEndpoint : Controller
	{
        private readonly IMediator _mediator;
        public GetAllTrucksEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllTrucksQuery());
            if (result.Any())
                return Ok(result);
                
            return NoContent();
        }
	}
}

