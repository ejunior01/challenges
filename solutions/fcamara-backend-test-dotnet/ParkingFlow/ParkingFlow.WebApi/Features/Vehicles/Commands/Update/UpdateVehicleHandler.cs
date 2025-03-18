using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public class UpdateVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateVehicleCommand, Result<Vehicle>>
{
    public async Task<Result<Vehicle>> Handle(UpdateVehicleCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await vehicleRepository.GetByPlateAsync(command.Plate);

        if (vehicle is null) return Result.Fail(new Error($"Vehicle {command.Plate} not found"));

        vehicle.ChangeBrand(command.Brand);
        vehicle.ChangeModel(command.Model);
        vehicle.ChangeColor(command.Color);
        vehicle.ChangeType(command.Type);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(vehicle);
    }
}