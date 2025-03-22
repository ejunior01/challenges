using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.Get;

public record GetVehicleByPlateQuery(string Plate) : IQuery<Result<Vehicle>>;

