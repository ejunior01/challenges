using System.Net;
using System.Text.Json;
using FluentResults;
using FluentValidation;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Common.Extensions;

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

        (var httpStatusCode, IReadOnlyCollection<string> errors) = GetHttpStatusCodeAndErrors(exception);
        
        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        httpContext.Response.ContentType = "application/json";

        Console.WriteLine(exception);
        
        httpContext.Response.StatusCode = (int) httpStatusCode;
        var response = JsonSerializer.Serialize(errors, serializerOptions);
        await httpContext.Response.WriteAsync(response);
    }
    
    private static (HttpStatusCode httpStatusCode, IReadOnlyCollection<string>) GetHttpStatusCodeAndErrors(Exception exception) =>
        exception switch
        {
            CustomValidationException validationException => (HttpStatusCode.BadRequest, validationException.Errors),
            BadHttpRequestException badHttpRequestException => (HttpStatusCode.BadRequest, ["Invalid request body."]),
            _ => (HttpStatusCode.InternalServerError, ["The server encountered an unrecoverable error."])
        };
}