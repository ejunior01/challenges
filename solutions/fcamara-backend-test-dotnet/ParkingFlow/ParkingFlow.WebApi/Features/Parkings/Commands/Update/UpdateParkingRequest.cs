namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public sealed record UpdateParkingRequest(
    string Name,
    string CNPJ,
    string Street,
    string Number,
    string District,
    string City,
    string State,
    string Postcode,
    string Phone,
    int CapacityCar,
    int CapacityMotorcycle);