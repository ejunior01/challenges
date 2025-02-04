using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.GetVehicleByPlate;

namespace ParkingFlow.WebApi.Features.Vehicles.DeleteVehicle;

public class GetVehicleByPlateEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"api/v1/{ApiRoutes.Vehicles.GetById}", Handler)
            .WithTags("Vehicles")
            .WithSummary("Get vehicle by plate");
    }

    private static async Task<IResult> Handler(
        string plate,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new GetVehicleByPlateQuery(plate);
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed ? TypedResults.NotFound(result.Errors) : TypedResults.Ok();
    }
}