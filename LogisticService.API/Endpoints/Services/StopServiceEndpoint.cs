using System;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.API.Endpoints.Trucks
{
    [Tags("Services")]
    [Route("api/services")]
    [Produces("application/json")]
    [ApiController]
    public class CreateServiceEndpoint : Controller
	{
		public CreateServiceEndpoint()
		{
		}
	}
}

