using System;
using System.Net;
using System.Text.Json;
using LogisticService.Domain.Exceptions;

namespace LogisticService.API.ExceptionHandler
{
	public class GlobalExceptionHandler
	{
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string result = JsonSerializer.Serialize(new { Message = error?.Message });

                switch (error)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case CustomValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        result = error?.Message;
                        break;
                    case ConflictException e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(result);
            }
        }
    }
}

