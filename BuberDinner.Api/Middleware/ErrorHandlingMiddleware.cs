using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;   

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context.Response, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpResponse response, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request" });
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            return response.WriteAsync(result);
        }
    }
}