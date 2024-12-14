﻿using FluentResults;
using MediatR;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteVehicleCommand, Result>
{
    public async Task<Result> Handle(DeleteVehicleCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await vehicleRepository.GetByPlate(command.Plate);

        if (vehicle is null) return Result.Fail(new Error($"Vehicle {command.Plate} not found"));;
        
        vehicleRepository.Remove(vehicle);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}