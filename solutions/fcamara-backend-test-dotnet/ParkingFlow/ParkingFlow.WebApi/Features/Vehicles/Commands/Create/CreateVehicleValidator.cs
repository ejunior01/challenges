using FluentValidation;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Create;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleValidator()
    {
        RuleFor(v => v.Model)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(v => v.Brand)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(v => v.Color)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(v => v.Type)
            .IsInEnum()
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Plate)
            .NotNull()
            .NotEmpty()
            .Matches(@"(^[a-zA-z]{3}-\d{4}$)|(^[a-zA-z]{3}\d{1}[a-zA-z]{1}\d{2}$)");
    }
}