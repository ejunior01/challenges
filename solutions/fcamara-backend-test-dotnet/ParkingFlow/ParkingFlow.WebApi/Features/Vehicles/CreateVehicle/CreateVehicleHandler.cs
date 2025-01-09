using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Vehicles;
using Plate = ParkingFlow.WebApi.Domain.Vehicles.Plate;

namespace ParkingFlow.WebApi.Features.Vehicles.CreateVehicle;

public class CreateVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateVehicleCommand, Result<Vehicle>>
{
    public async Task<Result<Vehicle>> Handle(CreateVehicleCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicleExistWithPlate = await vehicleRepository.ExistsVehicleByPlateAsync(command.Plate);

        if (vehicleExistWithPlate) return Result.Fail(new Error($"Vehicle {command.Plate} already exists"));

        var vehicle = new Vehicle(
            command.Brand,
            command.Model,
            command.Color,
            Plate.Create(command.Plate),
            command.Type);

        vehicleRepository.Add(vehicle);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(vehicle);
    }
}