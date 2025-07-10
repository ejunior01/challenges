using FluentResults;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public record UpdateVehicleCommand(
    Guid Id,
    string Brand,
    string Model,
    string Color,
    string Plate,
    TypeVehicle Type
) : ICommand<Result<VehicleResponse>>;