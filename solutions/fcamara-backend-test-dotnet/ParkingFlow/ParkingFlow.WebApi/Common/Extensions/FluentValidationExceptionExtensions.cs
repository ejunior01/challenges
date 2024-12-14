using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace ParkingFlow.WebApi.Common.Extensions;

public static class FluentValidationExceptionExtensions
{
    public static IReadOnlyCollection<Error> ToResultErrors(this ValidationException validationResult)
    {
        return validationResult.Errors
            .Distinct()
            .Select(
                failure => new Error(failure.ErrorMessage)
            )
            .ToList();
    }
}