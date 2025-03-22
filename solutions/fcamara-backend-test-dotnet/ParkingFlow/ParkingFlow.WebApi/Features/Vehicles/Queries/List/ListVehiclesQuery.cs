using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.List;

public record ListVehiclesQuery(int Page = 1, int PageSize = 10) : IQuery<Result<PagedList<Vehicle>>>;

