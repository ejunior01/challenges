using FluentValidation;
using MediatR;
using ParkingFlow.WebApi.Common.Abstracts;
using ParkingFlow.WebApi.Exceptions;

namespace ParkingFlow.WebApi.Common.Behaviors;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IBaseRequest
{
    public async Task<TResponse> Handle(TRequest request
        , RequestHandlerDelegate<TResponse> next
        , CancellationToken cancellationToken
    )
    {
        if (request is IQuery<TResponse>) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Count != 0)
            throw new CustomValidationException(failures);

        return await next();
    }
}