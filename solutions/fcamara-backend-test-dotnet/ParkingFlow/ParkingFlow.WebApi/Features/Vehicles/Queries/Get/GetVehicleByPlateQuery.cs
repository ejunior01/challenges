using FluentResults;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Queries.Get;

public record GetVehicleByPlateQuery(string Plate) : IQuery<Result<Vehicle>>;

