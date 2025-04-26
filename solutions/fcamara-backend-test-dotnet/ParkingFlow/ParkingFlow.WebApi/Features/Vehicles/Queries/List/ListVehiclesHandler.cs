using FluentResults;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.List;
public class ListVehiclesHandler(ParkingFlowDbContext context) :
    IQueryHandler<ListVehiclesQuery, Result<PagedList<Vehicle>>>
{
    public async Task<Result<PagedList<Vehicle>>> Handle(
        ListVehiclesQuery query,
        CancellationToken cancellationToken = default)
    {

        var vehicleQuery = context.Set<Vehicle>().AsQueryable();
        var total = await vehicleQuery.CountAsync(cancellationToken);

        var vehicles = await vehicleQuery
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);

        var pagedList = new PagedList<Vehicle>(vehicles, query.Page, query.PageSize, total);

        return Result.Ok(pagedList);
    }
}


