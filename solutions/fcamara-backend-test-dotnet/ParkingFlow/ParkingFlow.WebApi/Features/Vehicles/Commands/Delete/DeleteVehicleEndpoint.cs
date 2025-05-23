﻿using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Delete;

public class DeleteVehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete($"api/v1/{ApiRoutes.Vehicles.Delete}", Handler)
            .WithTags("Vehicles")
            .WithSummary("Delete vehicle");
    }

    private static async Task<IResult> Handler(
        string plate,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new DeleteVehicleCommand(plate);
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed ? TypedResults.NotFound(result.Errors) : TypedResults.Ok();
    }
}