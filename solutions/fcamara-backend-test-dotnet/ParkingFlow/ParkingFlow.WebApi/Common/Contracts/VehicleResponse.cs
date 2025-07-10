using ParkingFlow.Domain.Vehicles;
using System.Text.Json.Serialization;

namespace ParkingFlow.WebApi.Common.Contracts;

public class VehicleResponse(Guid Id, string brand, string model, string color, string plate, TypeVehicle type)
{
    public Guid Id { get; init; } = Id;
    public string Brand { get; init; } = brand;
    public string Model { get; init; } = model;
    public string Color { get; init; } = color;
    public string Plate { get; init; } = plate;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TypeVehicle Type { get; init; } = type;


    public static implicit operator VehicleResponse(Vehicle vehicle)
    {
        return new VehicleResponse(vehicle.Id,vehicle.Brand, vehicle.Model, vehicle.Color, vehicle.Plate.Value, vehicle.Type);
    }

    public override string ToString() => $$"""
        VehicleResponse:
            Id: {{Id}}
            Brand: {{Brand}}
            Model: {{Model}}
            Color: {{Color}}
            Plate: {{Plate}}
            Type: {{Type}}
        """;
}
