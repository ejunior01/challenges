using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public class UpdateParkingEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut($"api/v1/{ApiRoutes.Parkings.Update}", Handler)
            .WithTags("Parkings")
            .WithSummary("Update parking");
    }

    private static async Task<IResult> Handler(
        [FromRoute] Guid id,
        UpdateParkingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        
        var command = new UpdateParkingCommand(
                                id,
                                request.Name,
                                request.CNPJ,
                                request.Street,
                                request.Number,
                                request.District,
                                request.City,
                                request.State,
                                request.Postcode,
                                request.Phone,
                                request.CapacityCar,
                                request.CapacityMotorcycle);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailed) return TypedResults.NotFound(result.Errors);

        return TypedResults.Ok(result.Value);
    }
}