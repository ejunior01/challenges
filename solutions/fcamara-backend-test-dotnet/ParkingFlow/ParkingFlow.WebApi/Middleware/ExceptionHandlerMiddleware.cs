using ParkingFlow.WebApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace ParkingFlow.WebApi.Middleware;

internal class ExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        Console.WriteLine(exception);
        var (httpStatusCode, errors) = GetHttpStatusCodeAndErrors(exception);

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;
        var response = JsonSerializer.Serialize(errors, serializerOptions);
        await httpContext.Response.WriteAsync(response);
    }

    private static (HttpStatusCode httpStatusCode, IReadOnlyCollection<string>) GetHttpStatusCodeAndErrors(
        Exception exception)
    {
        return exception switch
        {
            CustomValidationException validationException => (HttpStatusCode.BadRequest, validationException.Errors),
            BadHttpRequestException badHttpRequestException => (HttpStatusCode.BadRequest, ["Invalid request body."]),
            _ => (HttpStatusCode.InternalServerError, [exception.Message])
            /*_ => (HttpStatusCode.InternalServerError, ["The server encountered an unrecoverable error."])*/
        };
    }
}