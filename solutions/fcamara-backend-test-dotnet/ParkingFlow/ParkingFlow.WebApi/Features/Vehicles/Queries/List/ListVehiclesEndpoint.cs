using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.List;
public class ListVehiclesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"api/v1/{ApiRoutes.Vehicles.Get}", Handler)
            .WithTags("Vehicles")
            .WithSummary("List vehicles");
    }

    private static async Task<IResult> Handler(
         ISender sender,
        CancellationToken cancellationToken,
        [FromQuery] int page=1,
        [FromQuery] int pageSize=10
       )
    {
        var query = new ListVehiclesQuery(page, pageSize);
        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
}