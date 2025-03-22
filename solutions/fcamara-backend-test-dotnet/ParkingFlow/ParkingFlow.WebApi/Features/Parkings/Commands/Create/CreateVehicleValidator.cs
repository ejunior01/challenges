using FluentValidation;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Create;

public class CreateParkingValidator : AbstractValidator<CreateParkingCommand>
{
    public CreateParkingValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
        RuleFor(x => x.CNPJ).NotEmpty();
        RuleFor(x => x.Street).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Number).NotEmpty().MinimumLength(1).MaximumLength(10);
        RuleFor(x => x.District).NotEmpty().MinimumLength(2);
        RuleFor(x => x.City).NotEmpty().MinimumLength(2);
        RuleFor(x => x.State).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Postcode).NotEmpty().MinimumLength(8).MaximumLength(9);
        RuleFor(x => x.Phone).NotEmpty().MinimumLength(8).MaximumLength(15);
        RuleFor(x => x.CapacityCar).GreaterThan(0);
        RuleFor(x => x.CapacityMotorcycle).GreaterThan(0);
    }
}