using System;
using System.Net;
using LogisticService.Application.Queries.Services.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LogisticService.API.Endpoints.Trucks
{
    [Tags("Services")]
    [Route("api/services")]
    [Produces("application/json")]
    [ApiController]
    public class GetAllServicesEndpoint : Controller
	{
		private readonly IMediator _mediator;
        public GetAllServicesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            if (result.Any())
                return Ok(result);
                
            return NoContent();
        }
	}
}

