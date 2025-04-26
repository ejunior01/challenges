using FluentResults;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public class UpdateVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateVehicleCommand, Result<Vehicle>>
{
    public async Task<Result<Vehicle>> Handle(UpdateVehicleCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await vehicleRepository.GetByPlateAsync(command.Plate);

        if (vehicle is null) return Result.Fail(new Error($"Vehicle {command.Plate} not found"));

        var plate = Plate.Create(command.Plate);

        vehicle.Update(command.Brand, command.Model, command.Color, plate, command.Type);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(vehicle);
    }
}