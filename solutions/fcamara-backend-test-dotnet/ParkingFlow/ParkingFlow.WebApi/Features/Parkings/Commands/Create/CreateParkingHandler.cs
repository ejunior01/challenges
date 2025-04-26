using FluentResults;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Create;

public class CreateParkingHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateParkingCommand, Result<Parking>>
{
    public async Task<Result<Parking>> Handle(CreateParkingCommand command,
        CancellationToken cancellationToken = default)
    {
        var parkingExistWithName = await parkingRepository.ExistsParkingByNameAsync(command.Name);

        if (parkingExistWithName) return Result.Fail(new Error($"Parkings {command.Name} already exists"));

        var cnpj = CNPJ.Create(command.CNPJ);

        if(cnpj.IsFailed)
        {
            return Result.Fail<Parking>(cnpj.Errors);
        }

        var parking = new Parking(command.Name, cnpj.Value, command.Street, command.Number, command.District, command.City, command.State,
            command.Postcode, command.Phone, command.CapacityCar, command.CapacityMotorcycle);

        parkingRepository.Add(parking);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(parking);
    }
}