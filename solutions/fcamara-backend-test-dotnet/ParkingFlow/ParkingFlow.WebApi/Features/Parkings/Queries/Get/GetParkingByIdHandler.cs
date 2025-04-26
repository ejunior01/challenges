using FluentResults;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.Get;
public class GetParkingByIdHandler(ParkingFlowDbContext context) :
    IQueryHandler<GetParkingByIdQuery, Result<Parking>>
{
    public async Task<Result<Parking>> Handle(
        GetParkingByIdQuery query,
        CancellationToken cancellationToken = default)
    {

        var parking = await context.Set<Parking>().FirstOrDefaultAsync(v => v.Id == query.Id, cancellationToken);

        if (parking is null) return Result.Fail(new Error($"Parking {query.Id} not found"));

        return Result.Ok(parking);
    }
}