using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.CreateVehicle;

public class CreateVehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost($"api/v1/{ApiRoutes.Vehicles.Create}", Handler)
            .WithTags("Vehicles")
            .WithSummary("Create vehicle");
    }

    private static async Task<IResult> Handler(CreateVehicleCommand command, ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed
            ? TypedResults.BadRequest(result.Errors)
            : TypedResults.Created($"api/v1/{ApiRoutes.Vehicles.Get}/{result.Value.Plate}", result.Value);
    }
}