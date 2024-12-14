using FluentResults;
using MediatR;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Features.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(
    string Brand,
    string Model,
    string Color,
    string Plate,
    TypeVehicle Type
) : ICommand<Result<Vehicle>>;