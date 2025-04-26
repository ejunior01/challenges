using FluentResults;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Parkings.Queries.Get;

public record GetParkingByIdQuery(Guid Id) : IQuery<Result<Parking>>;
