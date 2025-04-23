using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.Get;

public record GetParkingByIdQuery(Guid Id) : IQuery<Result<Parking>>;
