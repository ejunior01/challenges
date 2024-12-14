using FluentValidation.Results;

namespace ParkingFlow.WebApi.Common.Contracts;

public sealed class CustomValidationException : Exception
{
    public CustomValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation failures has occurred.")
    {
        Errors = failures
            .Distinct()
            .Select(failure => failure.ErrorMessage)
            .ToList();
    }

    public IReadOnlyCollection<string> Errors { get; }
}