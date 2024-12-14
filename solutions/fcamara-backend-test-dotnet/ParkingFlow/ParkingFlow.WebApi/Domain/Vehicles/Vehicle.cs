namespace ParkingFlow.WebApi.Domain.Vehicles;

public class Vehicle
{
    private Vehicle(){}
    public Vehicle(string brand, string model, string color, Plate plate, TypeVehicle type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand, nameof(brand));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, brand.Length, nameof(brand));
        ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, model.Length, nameof(model));
        ArgumentException.ThrowIfNullOrWhiteSpace(color, nameof(color));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, color.Length, nameof(color));
    
        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

    public Guid Id { get; private set; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public Plate Plate { get; private set; }
    public TypeVehicle Type { get; private set; }

    public void ChangeBrand(string brand)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand, nameof(brand));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, brand.Length, nameof(brand));
        Brand = brand;
    }

    public void ChangeModel(string model)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model, nameof(model));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, model.Length, nameof(model));
        Model = model;
    }

    public void ChangeColor(string color)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(color, nameof(color));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, color.Length, nameof(color));
        Color = color;
    }

    public void ChangeType(TypeVehicle type)
    {
        Type = type;
    }
}