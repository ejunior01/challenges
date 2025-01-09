using MediatR;

namespace ParkingFlow.WebApi.Common.Abstracts;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}