using MediatR;

namespace ParkingFlow.WebApi.Common.Abstracts;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}