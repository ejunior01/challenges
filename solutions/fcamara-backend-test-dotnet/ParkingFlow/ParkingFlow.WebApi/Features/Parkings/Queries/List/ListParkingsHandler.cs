using FluentResults;
using Microsoft.EntityFrameworkCore;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Parkings;
using ParkingFlow.WebApi.Persistence.Database;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.List;

public class ListParkingsHandler(ParkingFlowDbContext context) :
    IQueryHandler<ListParkingsQuery, Result<PagedList<Parking>>>
{
    public async Task<Result<PagedList<Parking>>> Handle(
        ListParkingsQuery query,
        CancellationToken cancellationToken = default)
    {

        var parkingQuery = context.Set<Parking>().AsQueryable();
        var total = await parkingQuery.CountAsync(cancellationToken);

        var parkings = await parkingQuery
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);

        var pagedList = new PagedList<Parking>(parkings, query.Page, query.PageSize, total);

        return Result.Ok(pagedList);
    }
}