using ParkingFlow.Domain.Vehicles;
using System.Text.Json.Serialization;

namespace ParkingFlow.WebApi.Features.Vehicles.Commands.Update;

public class UpdateVehicleRequest(Guid Id, string brand, string model, string color, string plate, TypeVehicle type)
{
    public Guid Id { get; set; } = Id;
    public string Brand { get; set; } = brand;
    public string Model { get; set; } = model;
    public string Color { get; set; } = color;
    public string Plate { get; set; } = plate;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TypeVehicle Type { get; set; } = type;
}