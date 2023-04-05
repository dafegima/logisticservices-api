using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
using LogisticService.Application.Commands.Services.Create;

namespace LogisticService.API.Endpoints.Services
{
    [Tags("Services")]
    [Route("api/services")]
    [Produces("application/json")]
    [ApiController]
    public class CreateServiceEndpoint : Controller
	{
        private readonly IMediator _mediator;
		public CreateServiceEndpoint(IMediator mediator)
		{
            _mediator = mediator;
		}

        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.Conflict)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

