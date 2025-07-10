using FluentResults;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public class UpdateVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateVehicleCommand, Result<VehicleResponse>>
{
    public async Task<Result<VehicleResponse>> Handle(UpdateVehicleCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await vehicleRepository.GetByPlateAsync(command.Plate);

        if (vehicle is null) return Result.Fail(new Error($"Vehicle {command.Plate} not found"));

        var plate = Plate.Create(command.Plate);

        vehicle.Update(command.Brand, command.Model, command.Color, plate, command.Type);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        VehicleResponse vehicleResponse = vehicle;

        return Result.Ok(vehicleResponse);
    }
}