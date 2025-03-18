using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Delete;

public class DeleteParkingEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete($"api/v1/{ApiRoutes.Parkings.Delete}", Handler)
            .WithTags("Parkings")
            .WithSummary("Delete parking");
    }

    private static async Task<IResult> Handler(
        Guid id,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new DeleteParkingCommand(id);
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed ? TypedResults.NotFound(result.Errors) : TypedResults.Ok();
    }
}