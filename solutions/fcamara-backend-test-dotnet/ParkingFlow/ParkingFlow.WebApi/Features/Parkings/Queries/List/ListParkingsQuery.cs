using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.List;

public record ListParkingsQuery(int Page = 1, int PageSize = 10) : IQuery<Result<PagedList<Parking>>>;

