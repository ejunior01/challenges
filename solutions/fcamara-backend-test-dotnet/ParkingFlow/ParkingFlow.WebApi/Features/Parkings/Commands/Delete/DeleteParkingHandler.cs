using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Domain.Parkings;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Delete;

public class DeleteParkingHandler(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteParkingCommand, Result>
{
    public async Task<Result> Handle(DeleteParkingCommand command,
        CancellationToken cancellationToken = default)
    {
        var vehicle = await parkingRepository.GetParkingByIdAsync(command.Id);

        if (vehicle is null) return Result.Fail(new Error($"Parkings {command.Id} not found"));

        parkingRepository.Remove(vehicle);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}