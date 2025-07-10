using FluentResults;
using ParkingFlow.Domain.Vehicles;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Common.Contracts;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Create;

public class CreateVehicleHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateVehicleCommand, Result<VehicleResponse>>
{
    public async Task<Result<VehicleResponse>> Handle(CreateVehicleCommand command,
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

        VehicleResponse vehicleResponse = vehicle;

        return Result.Ok(vehicleResponse);
    }
}