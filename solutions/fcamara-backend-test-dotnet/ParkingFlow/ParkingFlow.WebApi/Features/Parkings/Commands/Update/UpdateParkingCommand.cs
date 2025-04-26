using FluentResults;
using ParkingFlow.Domain.Parkings;
using ParkingFlow.WebApi.Common.Abstracts;

namespace ParkingFlow.WebApi.Features.Parkings.Commands.Update;

public record UpdateParkingCommand(
    Guid Id,
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
    int CapacityMotorcycle
) : ICommand<Result<Parking>>;