using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public class UpdateVehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut($"api/v1/{ApiRoutes.Vehicles.Update}", Handler)
            .WithTags("Vehicles")
            .WithSummary("Update vehicle");
    }

    private static async Task<IResult> Handler(
        [FromRoute] string plate,
        UpdateVehicleRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(plate)) return TypedResults.BadRequest("Invalid plate");

        if (!plate.Equals(request.Plate)) return TypedResults.UnprocessableEntity("Invalid plate");

        var command =
            new UpdateVehicleCommand(request.Brand, request.Model, request.Color, plate, request.Type);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailed) return TypedResults.NotFound(result.Errors);

        return TypedResults.Ok(result.Value);
    }
}