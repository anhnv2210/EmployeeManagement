using ems_backend.Models.Response;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ems_backend.Common.Midlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(context, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            var responseObject = new ResponseObject<string>
            {
                Status = statusCode,
                Message = message,
                Data = null
            };

            var result = JsonConvert.SerializeObject(responseObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
