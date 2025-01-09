using MediatR;

namespace ParkingFlow.WebApi.Common.Abstracts;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}