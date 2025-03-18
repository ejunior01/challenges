using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Create;

public class CreateParkingHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateParkingCommand, Result<Parking>>
{
    public async Task<Result<Parking>> Handle(CreateParkingCommand command,
        CancellationToken cancellationToken = default)
    {
        var parkingExistWithName = await parkingRepository.ExistsParkingByNameAsync(command.Name);

        if (parkingExistWithName) return Result.Fail(new Error($"Parkings {command.Name} already exists"));

        var address = Address.Create(command.Street, command.Number, command.District, command.City, command.State,
            command.Postcode);

        var cnpj = CNPJ.Create(command.CNPJ);

        var parking = new Parking(command.Name, cnpj, address, command.Phone, command.CapacityCar, command.CapacityMotorcycle);

        parkingRepository.Add(parking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(parking);
    }
}