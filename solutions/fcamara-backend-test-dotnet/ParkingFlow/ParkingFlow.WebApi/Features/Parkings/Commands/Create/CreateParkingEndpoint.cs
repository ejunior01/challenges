using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Create;

public class CreateParkingEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost($"api/v1/{ApiRoutes.Parkings.Create}", Handler)
            .WithTags("Parkings")
            .WithSummary("Create parking");
    }

    private static async Task<IResult> Handler(CreateParkingCommand command, ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed
            ? TypedResults.Conflict(result.Errors)
            : TypedResults.Created($"api/v1/{ApiRoutes.Parkings.Get}/{result.Value.Id}", result.Value);
    }
}