using FluentResults;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.Get;
public class GetVehicleByPlateHandler(ParkingFlowDbContext context) :
    IQueryHandler<GetVehicleByPlateQuery, Result<Vehicle>>
{
    public async Task<Result<Vehicle>> Handle(
        GetVehicleByPlateQuery query,
        CancellationToken cancellationToken = default)
    {

        var vehicle = await context.Set<Vehicle>().FirstOrDefaultAsync(v => v.Plate.Value.Equals(query.Plate), cancellationToken);

        if (vehicle is null) return Result.Fail(new Error($"Vehicle {query.Plate} not found"));

        return Result.Ok(vehicle);
    }
}


