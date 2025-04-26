using ParkingFlow.Domain.Core.Abstracts;
using ParkingFlow.Domain.Core.Guards;

namespace ParkingFlow.Domain.Vehicles;

public class Vehicle : Entity
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public Plate Plate { get; private set; }
    public TypeVehicle Type { get; private set; }

    private Vehicle() { }

    public Vehicle(string brand, string model, string color, Plate plate, TypeVehicle type) : base()
    {
        ValidateInputs(brand, model, color, plate);

        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

    private static void ValidateInputs(string brand, string model, string color, Plate plate)
    {
        brand.NotEmpty().MinLength(2);
        model.NotEmpty().MinLength(2);
        color.NotEmpty().MinLength(2);
        plate.NotNull();
    }

    public void Update(string brand, string model, string color, Plate plate, TypeVehicle type)
    {
        ValidateInputs(brand, model, color, plate);

        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

}