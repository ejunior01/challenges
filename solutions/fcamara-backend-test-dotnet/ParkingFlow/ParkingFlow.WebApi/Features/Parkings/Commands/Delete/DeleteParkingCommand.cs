using FluentResults;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Delete;

public record DeleteParkingCommand(
    Guid Id
) : ICommand<Result>;