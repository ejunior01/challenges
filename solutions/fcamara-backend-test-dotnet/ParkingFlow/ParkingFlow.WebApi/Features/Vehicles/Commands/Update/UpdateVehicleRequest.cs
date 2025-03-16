using ParkingFlow.WebApi.Domain.Vehicles;

namespace ParkingFlow.WebApi.Features.Vehicles.UpdateVehicle;

public class UpdateVehicleRequest(string brand, string model, string color, string plate, TypeVehicle type)
{
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public string Color { get; set; } = color;
    public string Plate { get; set; } = plate;
    public TypeVehicle Type { get; set; } = type;
}