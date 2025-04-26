using FluentValidation;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Delete;

public class DeleteParkingValidator : AbstractValidator<DeleteParkingCommand>
{
    public DeleteParkingValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}