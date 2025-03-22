using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public class UpdateParkingHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateParkingCommand, Result<Parking>>
{
    public async Task<Result<Parking>> Handle(UpdateParkingCommand command,
        CancellationToken cancellationToken = default)
    {
        
        var address = Address.Create(command.Street,command.Number,command.District,command.City,command.State,command.Postcode);
        var cnpj = CNPJ.Create(command.CNPJ);
        
        var parking = await parkingRepository.GetParkingByIdAsync(command.Id);

        if (parking is null) return Result.Fail(new Error($"Parking {command.Id} not found"));

        parking.Update(command.Name,cnpj,address,command.Phone,command.CapacityCar,command.CapacityMotorcycle);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(parking);
    }
}