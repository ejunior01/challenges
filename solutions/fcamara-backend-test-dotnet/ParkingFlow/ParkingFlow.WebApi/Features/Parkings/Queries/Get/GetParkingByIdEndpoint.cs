using Carter;
using MediatR;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.Get;

public class GetParkingByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"api/v1/{ApiRoutes.Parkings.GetById}", Handler)
            .WithTags("Parkings")
            .WithSummary("Get parking by id");
    }

    private static async Task<IResult> Handler(
        Guid id,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new GetParkingByIdQuery(id);
        var result = await sender.Send(command, cancellationToken);

        return result.IsFailed ? TypedResults.NotFound(result.Errors) : TypedResults.Ok();
    }
}