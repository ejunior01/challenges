using FluentResults;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public class UpdateParkingHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateParkingCommand, Result<Parking>>
{
    public async Task<Result<Parking>> Handle(UpdateParkingCommand command,
        CancellationToken cancellationToken = default)
    {

        var cnpj = CNPJ.Create(command.CNPJ);

        var parking = await parkingRepository.GetParkingByIdAsync(command.Id);

        if (parking is null) return Result.Fail(new Error($"Parking {command.Id} not found"));

        parking.Update(command.Name, cnpj, command.Street, command.Number, command.District, command.City, command.State, command.Postcode, command.Phone, command.CapacityCar, command.CapacityMotorcycle);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(parking);
    }
}