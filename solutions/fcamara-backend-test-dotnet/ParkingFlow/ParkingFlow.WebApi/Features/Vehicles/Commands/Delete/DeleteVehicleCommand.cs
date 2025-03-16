using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Delete;

public record DeleteVehicleCommand(
    string Plate
) : ICommand<Result>;