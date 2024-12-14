using MediatR;

namespace ParkingFlow.WebApi.Common.Abstracts;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}