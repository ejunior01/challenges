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
        string response;
        
        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        httpContext.Response.ContentType = "application/json";

        if (exception is CustomValidationException validationException)
        {
            httpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            response = JsonSerializer.Serialize(validationException.Errors, serializerOptions);
        }
        else
        {
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            response = JsonSerializer.Serialize("The server encountered an unrecoverable error.", serializerOptions);
        }
        
        await httpContext.Response.WriteAsync(response);
    }
}