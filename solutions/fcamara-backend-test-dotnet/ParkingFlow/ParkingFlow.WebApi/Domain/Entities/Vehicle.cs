using ParkingFlow.WebApi.Domain.Enums;

namespace ParkingFlow.WebApi.Domain.Entities;

public class Vehicle
{
    public Vehicle(string brand, string model, string color, string plate, TypeVehicle type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brand,  nameof(brand));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, brand.Length, nameof(brand));
        ArgumentException.ThrowIfNullOrWhiteSpace(model,  nameof(model));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, model.Length, nameof(model));
        ArgumentException.ThrowIfNullOrWhiteSpace(color,  nameof(color));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, color.Length, nameof(color));
        ArgumentException.ThrowIfNullOrWhiteSpace(plate,  nameof(plate));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(2, plate.Length, nameof(plate));
        
        Brand = brand;
        Model = model;
        Color = color;
        Plate = plate;
        Type = type;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string Plate { get; private set; }
    public TypeVehicle Type { get; private set; }
}