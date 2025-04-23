using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.List;

public class ListParkingsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"api/v1/{ApiRoutes.Parkings.Get}", Handler)
            .WithTags("Parkings")
            .WithSummary("List parkings");
    }

    private static async Task<IResult> Handler(
         ISender sender,
        CancellationToken cancellationToken,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
       )
    {
        var query = new ListParkingsQuery(page, pageSize);
        var result = await sender.Send(query, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
}