using HRManagment.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace HRManagment.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning("Validation error: {Errors}", ex.Errors);
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Errors);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning("Not found: {Message}", ex.Message);
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, new List<string> { "Beklenmeyen bir hata oluştu." });
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, List<string> errors)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                isSuccess = false,
                errors
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}