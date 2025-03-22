using FluentValidation;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Delete;

public class DeleteVehicleValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleValidator()
    {
        RuleFor(v => v.Plate)
            .NotNull()
            .NotEmpty()
            .Matches(@"(^[a-zA-z]{3}-\d{4}$)|(^[a-zA-z]{3}\d{1}[a-zA-z]{1}\d{2}$)");
    }
}